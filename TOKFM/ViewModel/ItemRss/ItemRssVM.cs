using Commander;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TOKFM.Model;
using TOKFM.ViewModel;

namespace TOKFM
{
    [ImplementPropertyChanged]
    public class ItemRssVM : ItemRss
    { 
        public ItemRssVM(ushort guid,string title, string summary, DateTime timePublish, string duration, string url, string image, string actualTime)
        {
            this.Guid = guid;
            this.Title = title;
            this.Summary = summary;
            this.TimePublish = timePublish; 
            this.Duration = duration;
            this.ActualTime = actualTime;
            this.Url = url;
            this.Image = image;
        }
        public ItemRssVM()
        { }
    }
}
