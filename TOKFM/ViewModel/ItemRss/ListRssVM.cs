using Commander;
using HtmlAgilityPack;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using TOKFM.Helpers;
using TOKFM.Model;

namespace TOKFM.ViewModel.ViewModelPartial
{
    [ImplementPropertyChanged]
    public class ListRssVM
    {
        public ObservableCollection<ItemRssVM> Items { get; set; } = new ObservableCollection<ItemRssVM>();
        public Visibility IsLoaded { get; private set; } = Visibility.Hidden; 

        public delegate void GetFromRSSEvent();
        public event GetFromRSSEvent GetFromRSSDone;

        private ObservableCollection<ItemRssVM> getDataFromRSS(string url)
        {
            rss rssData = new rss();
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Timeout = 10000;  //[ms]
            httpRequest.UserAgent = " Web Client";
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
                XmlSerializer sr = new XmlSerializer(typeof(rss));
                rssData = (rss)sr.Deserialize(responseStream);
                responseStream.Close();

                ObservableCollection<ItemRssVM> listTemp = new ObservableCollection<ItemRssVM>();

                foreach (var item in rssData.channel.item)
                {
                    if (item.summary == "")
                    {
                        item.summary = item.title; 
                    }
                    listTemp.Add(new ItemRssVM(item.guid.Value, item.title, item.summary, DateTime.Parse(item.pubDate), item.duration, item.enclosure.url, item.image.href, "00:00"));
                }
                return listTemp;
            }
            catch
            {
                return null;
            }


        }

        private async Task<ObservableCollection<ItemRssVM>> getDataFromRSSAsync(string url)
        {
            return await Task.Run(() =>
            {
                return getDataFromRSS(url);
            });
        }

        public async void GetFromRSS(string url)
        {
            this.IsLoaded = Visibility.Visible;
            Items = await getDataFromRSSAsync(url);
            GetFromRSSDone();
            this.IsLoaded = Visibility.Hidden;
        }

        public void GetFromXML(string url)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(ObservableCollection<ItemRssVM>));
                StreamReader tr = new StreamReader(url);
                this.Items = (ObservableCollection<ItemRssVM>)sr.Deserialize(tr);
                tr.Close();
            }
            catch
            { }

        }

        public void SaveToXML(string url)
        {
            XmlSerializer sr = new XmlSerializer(typeof(ObservableCollection<ItemRssVM>));
            StreamWriter tw = new StreamWriter(url);
            sr.Serialize(tw, this.Items);
            tw.Flush();
            tw.Close();
        }
    }
}
