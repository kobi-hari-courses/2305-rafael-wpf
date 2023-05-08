using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BareBonesInXaml
{
    public class PersonConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return false;
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var str = value as string;
            var parts = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var p = new Person();

            try
            {
                if (parts.Length > 0) p.DisplayName = parts[0];
                if (parts.Length > 1) p.Age = int.Parse(parts[1]);
            } catch
            {

            }

            return p;

        }
    }
}
