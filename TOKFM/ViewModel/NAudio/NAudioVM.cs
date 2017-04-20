using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TOKFM.ViewModel.NAudio
{
    public class NAudioVM : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EventHandler FinishStreamEvent;

        private string inputPath;
        private IWavePlayer wavePlayer;
        private WaveStream reader;
        private DispatcherTimer timer = new DispatcherTimer();
        private double sliderPosition;
        private string actualTime;
        private string lastPlayed;

        private TimeSpan lastTime;
        private TimeSpan actTime;

        private float volume;
        public float Volume
        {
            get
            {
                wavePlayer.Volume = volume;
                return volume;
            }
            set
            {
                volume = value;
                if(wavePlayer != null)
                {
                    wavePlayer.Volume = volume;
                    OnPropertyChanged("Volume");
                } 
            }
        }


        public NAudioVM()
        {
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += TimerOnTick;
        }

        public bool IsPlaying
        {
            get { return wavePlayer != null && wavePlayer.PlaybackState == PlaybackState.Playing; }

        }

        public bool IsStopped
        {
            get { return wavePlayer == null || wavePlayer.PlaybackState == PlaybackState.Stopped; }
        }

        const double sliderMax = 100.0;

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (reader != null)
            {
                sliderPosition = Math.Min(sliderMax, reader.Position * sliderMax / reader.Length);
                actualTime =(reader.TotalTime - reader.CurrentTime).ToString(@"mm\:ss");
                OnPropertyChanged("SliderPosition");
                OnPropertyChanged("ActualTime");

                lastTime = actTime;
                actTime = reader.CurrentTime;

                if ((actTime == lastTime) && (wavePlayer.PlaybackState != PlaybackState.Paused))
                {
                    FinishStreamEvent(this, new EventArgs());
                }
            }
        }

        public string ActualTime
        {
            get
            {
                return actualTime;
            }
            set
            {
                if (actualTime != value)
                {
                    actualTime = value;
                    OnPropertyChanged("ActualTime");
                }
            }
        }

        public double SliderPosition
        {
            get { return sliderPosition; }
            set
            {
                if (sliderPosition != value)
                {
                    sliderPosition = value;
                    if (reader != null)
                    {
                        var pos = (long)(reader.Length * sliderPosition / sliderMax);
                        reader.Position = pos; // media foundation will worry about block align for us
                    }
                    OnPropertyChanged("SliderPosition");
                }
            }
        }

        private bool TryOpenInputFile(string file)
        {
            bool isValid = false;
            try
            {
                using (var tempReader = new MediaFoundationReader(file))
                {
                    InputPath = file;
                    isValid = true;
                }
            }
            catch (Exception e)
            {

            }
            return isValid;
        }

        public string InputPath
        {
            get { return inputPath; }
            set
            {
                if (inputPath != value)
                {
                    inputPath = value;
                    OnPropertyChanged("InputPath");
                }
            }
        }

        public void Stop()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
                SliderPosition = 0;
                //reader.Position = 0;
                timer.Stop();
                this.actualTime = "00:00";
                OnPropertyChanged("ActualTime");
                OnPropertyChanged("IsPlaying");
            }
        }

        public void Pause()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Pause();
                OnPropertyChanged("IsPlaying");
                OnPropertyChanged("IsStopped");
            }
        }

        public void Play()
        {
            if (wavePlayer == null)
            {
                CreatePlayer();
            }
            if ((lastPlayed != inputPath && reader != null))
            {
                try
                {
                    reader.Dispose();
                }
                catch
                {

                }

                reader = null;
            }
            if (reader == null)
            {
                reader = new MediaFoundationReader(inputPath);
                lastPlayed = inputPath;
                wavePlayer.Init(reader);
            }

            wavePlayer.Play();
            OnPropertyChanged("IsPlaying");
            OnPropertyChanged("IsStopped");
            timer.Start();
        }

        private void CreatePlayer()
        {
            wavePlayer = new WaveOutEvent();
            //wavePlayer.PlaybackStopped += WavePlayerOnPlaybackStopped;
        }

        private void WavePlayerOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {

            if (reader != null)
            {
                SliderPosition = 0;
                //reader.Position = 0;
                timer.Stop();
            }
            if (stoppedEventArgs.Exception != null)
            {

            }
            OnPropertyChanged("IsPlaying");
            OnPropertyChanged("IsStopped");

        }

        private void Load(string url)
        {
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
            if (TryOpenInputFile(url))
            {
                TryOpenInputFile(url);
            }
        }

        public void Dispose()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
            }
            if (reader != null)
            {
                reader.Dispose();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
