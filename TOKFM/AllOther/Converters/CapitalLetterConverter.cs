using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TOKFM
{
    public class CapitalLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateDateTime = (DateTime)value;
            string dateString = dateDateTime.ToString("dddd, d MMMM yyyy, HH:MM").Replace(",", " -");
            return dateString.First().ToString().ToUpper() + dateString.Substring(1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
