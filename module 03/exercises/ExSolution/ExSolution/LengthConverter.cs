using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExSolution
{
    public class LengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var length = (TimeSpan)value;

                var hours = length.Hours;
                var minutes = length.Minutes;

                if ((hours == 0) && (minutes == 30)) return "Half hour";
                if (minutes == 30) return $"{hours} hours and a half";
                if (hours == 0) return $"{minutes} minutes";
                if (minutes == 0) return $"{hours} hours";

                return $"{hours} hours and {minutes} minutes";

            }
            catch { }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
