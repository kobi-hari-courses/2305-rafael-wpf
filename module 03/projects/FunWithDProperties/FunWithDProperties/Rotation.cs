using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FunWithDProperties
{
    public static class Rotation
    {
        public static readonly DependencyProperty AngleProperty = DependencyProperty.RegisterAttached(
            "Angle", typeof(double), typeof(Rotation), new PropertyMetadata(0.0, OnAngleChanged));

        private static void OnAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var shape = d as Shape;
            if (shape == null) return;

            var angle = (double)e.NewValue;
            if ((shape.RenderTransform == null) || !(shape.RenderTransform is RotateTransform))
            {
                shape.RenderTransform = new RotateTransform();
            }

            var transform = (shape.RenderTransform as RotateTransform)!;
            transform.Angle = angle;

            shape.RenderTransformOrigin = new Point(0.5, 0.5);


        }

        public static double GetAngle(Shape shape)
        {
            return (double)shape.GetValue(AngleProperty);
        }

        public static void SetAngle(Shape shape, double value) 
        { 
            shape.SetValue(AngleProperty, value); 
        }

    }
}
