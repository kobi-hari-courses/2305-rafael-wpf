using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunWithDProperties
{
    public class CustomObject: FrameworkElement
    {
        public static readonly DependencyProperty AProperty = DependencyProperty.Register(
            nameof(A), typeof(int), typeof(CustomObject), new PropertyMetadata(42, OnAChanged, OnACoerced)
            );

        public static readonly DependencyProperty MaxProperty = DependencyProperty.Register(
            nameof(Max), typeof(int), typeof(CustomObject), new PropertyMetadata(90, OnMaxChanged)
            );

        private static readonly DependencyPropertyKey BPropertyKey = DependencyProperty.RegisterReadOnly(
            "B", typeof(int), typeof(CustomObject), new PropertyMetadata(52));

        public static readonly DependencyProperty BProperty = BPropertyKey.DependencyProperty;

        private static void OnMaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.InvalidateProperty(AProperty);
        }

        private static object OnACoerced(DependencyObject d, object baseValue)
        {
            var customObject = (d as CustomObject)!;
            var value = (int)baseValue;
            if (value > customObject.Max) return customObject.Max;

            return value;
        }

        private static void OnAChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Value A changed from {e.OldValue} to {e.NewValue} ");
            (d as CustomObject)!.B = (int)e.NewValue + 10;
        }

        public int Max
        {
            get
            {
                return (int)GetValue(MaxProperty);
            }
            set 
            { 
                SetValue(MaxProperty, value); 
            }
        }

        public int A
        {
            get
            {
                return (int)GetValue(AProperty);
            }
            set
            {
                SetValue(AProperty, value);
            }
        }

        public int B
        {
            get
            {
                return (int)GetValue(BProperty);
            }
            private set
            {
                SetValue(BPropertyKey, value);
            }
        }

    }
}
