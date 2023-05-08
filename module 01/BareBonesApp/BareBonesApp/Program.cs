using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BareBonesApp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var win = new Window();
            win.Title = "Hello WPF";

            var sp = new StackPanel();

            var tb = new TextBlock
            {
                Text = "Hello",
                Foreground = Brushes.Brown, 
                FontSize = 16.0, 
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            var ellipse = new Ellipse();
            ellipse.Width = 100;
            ellipse.Height = 100;
            ellipse.Fill = Brushes.Green;

            var btn = new Button
            {
                Content = "Click Me",
                Foreground = Brushes.Blue,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            sp.Children.Add(tb);
            sp.Children.Add(ellipse);
            sp.Children.Add(btn);

            win.Content= sp;

            var app = new Application();
            app.Run(win);
        }
    }
}
