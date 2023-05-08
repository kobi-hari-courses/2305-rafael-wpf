using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01Solution
{
    public class ScoreConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var str = (string)value;
            var res = new ExamScore();
            try
            {
                var parts = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                res.CorrectCount = int.Parse(parts[0]);
                res.WrongCount = int.Parse(parts[1]);
            }
            catch { }

            return res;
        }
    }
}
