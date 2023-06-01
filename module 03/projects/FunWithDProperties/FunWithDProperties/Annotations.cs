using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FunWithDProperties
{
    public static class Annotations
    {
        #region Badge

        public static string GetBadge(ButtonBase obj)
        {
            return (string)obj.GetValue(BadgeProperty);
        }

        public static void SetBadge(ButtonBase obj, string value)
        {
            obj.SetValue(BadgeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Badge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.RegisterAttached("Badge", typeof(string), typeof(Annotations), new PropertyMetadata(""));

        #endregion


        #region Brush

        public static Brush GetBrush(ButtonBase obj)
        {
            return (Brush)obj.GetValue(BrushProperty);
        }

        public static void SetBrush(ButtonBase obj, Brush value)
        {
            obj.SetValue(BrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.RegisterAttached("Brush", typeof(Brush), typeof(Annotations), new PropertyMetadata(Brushes.Red));



        #endregion



    }
}
