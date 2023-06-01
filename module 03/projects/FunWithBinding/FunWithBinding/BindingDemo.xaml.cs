using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunWithBinding
{
    /// <summary>
    /// Interaction logic for BindingDemo.xaml
    /// </summary>
    public partial class BindingDemo : UserControl
    {
        public BindingDemo()
        {
            InitializeComponent();
            var myBinding = new Binding("FavoriteColor");
            myBinding.Source = rootPanel.DataContext;
            BindingOperations.SetBinding(ellipseBrush, SolidColorBrush.ColorProperty, myBinding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var person = (rootPanel.DataContext as Person)!;
            person.FavoriteColor = Colors.LightGreen;

        }

    }
}
