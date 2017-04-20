using Commander;
using MoreLinq;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TOKFM.Helpers;
using TOKFM.Model;
using TOKFM.ViewModel.NAudio;
using TOKFM.ViewModel.ViewModelPartial;

namespace TOKFM.ViewModel
{
    [ImplementPropertyChanged]
    public class VModel
    {
        public NAudioVM StreamPlayer { get; set; } = new NAudioVM();
        public ListRssVM ListItemsRss { get; set; } = new ListRssVM();
        public ListRssVM ListItemsRssTemp { get; set; } = new ListRssVM();
        public int DirectionAutoPlay { get; set; } = 1;

        private ItemRssVM oldSelectedItem = new ItemRssVM();
        private string path = AppDomain.CurrentDomain.BaseDirectory + "Linki.xml";

        // timer
        DispatcherTimer timerRefreshPlaylist = new DispatcherTimer();



        public VModel()
        {
            timerRefreshPlaylist.Interval = TimeSpan.FromSeconds(10);
            timerRefreshPlaylist.Tick += timerRefreshPlaylistTick;
            timerRefreshPlaylist.Start();

            ListItemsRssTemp.GetFromRSSDone += new ListRssVM.GetFromRSSEvent(FinishedGetFromRSS);
            StreamPlayer.FinishStreamEvent += FinishStream;

            ListItemsRss.GetFromXML(path);

            if (ListItemsRss.Items.Count > 0)
            {
                selectedItem = ListItemsRss.Items[0];
                StreamPlayer.ActualTime = "00:00";
            }
            volume = 0.03f;
        }

        private ItemRssVM selectedItem;
        public ItemRssVM SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value != null)
                {
                    if ((selectedItem != null) && StreamPlayer.InputPath == null)
                    {
                        StreamPlayer.InputPath = selectedItem.Url;
                        StreamPlayer.Play();
                    }
                    if (StreamPlayer.InputPath != null)
                    {
                        selectedItem = value;
                        StreamPlayer.Stop();
                        StreamPlayer.InputPath = selectedItem.Url;
                        StreamPlayer.Play();
                    }
                    if (selectedItem == null)
                    {
                        selectedItem = value;
                        StreamPlayer.ActualTime = "00:00";
                    }
                }
            }
        }

        private float volume;
        public float Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                if (StreamPlayer != null)
                {
                    StreamPlayer.Volume = volume;
                }
            }
        }

        void timerRefreshPlaylistTick(object sender, EventArgs e)
        {
            ListItemsRssTemp.GetFromRSS("http://audycje.tokfm.pl/rss/a7c6a5012a556b");
            if (timerRefreshPlaylist.Interval.Seconds < 20)
            {
                timerRefreshPlaylist.Interval = TimeSpan.FromSeconds(1800);
            } 
        }


        #region RefreshListCommand
        [OnCommandCanExecute("RefreshListCommand")]
        public bool CanSeedList()
        {
            return StreamPlayer.IsStopped;
        }

        [OnCommand("RefreshListCommand")]
        public void OnSeedList()
        {
            ListItemsRssTemp.GetFromRSS("http://audycje.tokfm.pl/rss/a7c6a5012a556b");
        }

        public void FinishStream(object o, EventArgs e)
        {
            StreamPlayer.Stop();
            if (DirectionAutoPlay != 0)
            {
                int index = ListItemsRss.Items.ToList().FindIndex(a => a.Url == selectedItem.Url);
                int nextIndex = 0;

                if (DirectionAutoPlay == 1)
                {
                    nextIndex = index - 1;
                }
                else if (DirectionAutoPlay == 2)
                {
                    nextIndex = index + 1;
                }


                if ((ListItemsRss.Items.Count > nextIndex) && (nextIndex >= 0))
                {
                    SelectedItem = ListItemsRss.Items[nextIndex];
                    StreamPlayer.Play();
                }
            }

        }

        public void FinishedGetFromRSS()
        {
            foreach (ItemRssVM item in ListItemsRss.Items)
            {
                ListItemsRssTemp.Items.Add(item);
            }
            List<ItemRssVM> temp = ListItemsRssTemp.Items.DistinctBy(p => p.Guid).OrderByDescending(k => k.TimePublish).ToList();

            ListItemsRss.Items.Clear();
            foreach (ItemRssVM item in temp)
            {
                ListItemsRss.Items.Add(item);
            }
            if ((SelectedItem == null) && (ListItemsRss.Items.Count > 0))
            {
                SelectedItem = ListItemsRss.Items[0];
            }
            ListItemsRss.SaveToXML(path);
        }
        #endregion

        #region PlayCommand
        [OnCommandCanExecute("PlayCommand")]
        public bool CanPlay()
        {
            bool ret = false;
            if (!StreamPlayer.IsPlaying && SelectedItem != null)
            {
                ret = true;
            }
            return ret;
        }

        [OnCommand("PlayCommand")]
        public void Play()
        {
            StreamPlayer.InputPath = selectedItem.Url;
            StreamPlayer.Play();
        }
        #endregion

        #region PauseCommand
        [OnCommandCanExecute("PauseCommand")]
        public bool CanPause()
        {
            return StreamPlayer.IsPlaying;
        }

        [OnCommand("PauseCommand")]
        public void Pause()
        {
            StreamPlayer.Pause();
        }
        #endregion

        #region StopCommand
        [OnCommandCanExecute("StopCommand")]
        public bool CanStop()
        {
            return !StreamPlayer.IsStopped;
        }

        [OnCommand("StopCommand")]
        public void Stop()
        {
            StreamPlayer.Stop();
        }
        #endregion

        #region DirectionCommand
        [OnCommandCanExecute("DirectionCommand")]
        public bool CanDirection()
        {
            return true;
        }

        [OnCommand("DirectionCommand")]
        public void Direction()
        {
            if (DirectionAutoPlay == 1)
            {
                DirectionAutoPlay = 2;
            }
            else if (DirectionAutoPlay == 0)
            {
                DirectionAutoPlay = 1;
            }
            else
            {
                DirectionAutoPlay = 0;
            }
        }
        #endregion
    }
}
