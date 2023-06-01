using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace FunWithBinding
{
    public class MinMaxValueToAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double res = 0;

            try
            {
                var min = (double)values[0];
                var max = (double)values[1];
                var val = (double)values[2];

                res = (val - min) / (max - min) * 80 - 40;
            }
            catch { }

            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
