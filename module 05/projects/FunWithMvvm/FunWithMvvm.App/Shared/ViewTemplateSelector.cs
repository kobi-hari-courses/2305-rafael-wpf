using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FunWithMvvm.App.Shared
{
    public class ViewTemplateSelector: DataTemplateSelector
    {
        private Type GetViewType(Type viewModelType)
        {
            var name = viewModelType.Name;
            if (name.ToLower().EndsWith("vm"))
            {
                var prefix = name.Substring(0, name.Length - 2);
                var fullName = $"{prefix}View";
                var assemblyQualifiedName = $"{viewModelType.Namespace}.{fullName}, {viewModelType.Assembly.FullName}";
                var res = Type.GetType(assemblyQualifiedName);

                return res!;
            }

            return null!;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) { return null!; }

            var vmType = item.GetType();
            var vType = GetViewType(vmType);

            var dataTemplate = DataTemplateWrapper.ForViewModel(vmType, vType);
            return dataTemplate;
                
        }
    }
}
