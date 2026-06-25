using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace Wpfz
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public BoolToVisibilityConverter()
        {
            this.Inverted = false;
        }
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            if (targetType == typeof(string))
            {
                return b.ToString();
            }

            if (targetType == typeof(Visibility))
            {
                if (b != this.Inverted)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility v)
            {
                if (v == Visibility.Visible)
                {
                    return !this.Inverted;
                }
                return this.Inverted;
            }
            throw new NotImplementedException();
        }
    }
}