using Commander;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOKFM.Model
{
    [ImplementPropertyChanged]
    public class ItemRss
    {
        public ushort Guid { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime TimePublish { get; set; }
        public string Duration { get; set; }
        public string ActualTime { get; set; }
        public string Image { get; set; }
    }
}
