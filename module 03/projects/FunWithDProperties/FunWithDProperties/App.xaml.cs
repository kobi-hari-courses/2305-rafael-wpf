using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FunWithDProperties
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var c = new CustomObject();
            var valueOfA = c.A;
            var source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);

            var style = new Style(typeof(CustomObject));
            style.Setters.Add(new Setter(CustomObject.AProperty, 100));
            c.Style = style;
            valueOfA = c.A;
            source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);

            c.Max = 80;
            valueOfA = c.A;
            source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);

            c.A = 50;
            valueOfA = c.A;
            source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);

            c.ClearValue(CustomObject.AProperty);
            valueOfA = c.A;
            source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);

            c.Style = null;
            valueOfA = c.A;
            source = DependencyPropertyHelper.GetValueSource(c, CustomObject.AProperty);


            c.SetValue(Button.BackgroundProperty, Brushes.Green);

            var colorOfC = c.GetValue(Button.BackgroundProperty);


        }
    }
}
