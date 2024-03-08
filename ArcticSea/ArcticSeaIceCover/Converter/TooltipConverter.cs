using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticSeaIceCover
{
    public class TooltipConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var year = value is Model ? (value as Model)!.Year : value;
            SolidColorBrush brush = (SolidColorBrush)Colors.Transparent;
            if (year!.Equals("2000"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#2196F3"));
            }
            else if (year.Equals("2005"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#25E739"));
            }
            else if (year.Equals("2010"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#F4890B"));
            }
            else if (year.Equals("2015"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#E2227E"));
            }
            else if (year.Equals("2020"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#116DF9"));
            }
            else if (year.Equals("2021"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#9215F3"));
            }
            else if (year.Equals("2022"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#FCD404"));
            }
            else if (year.Equals("2023"))
            {
                brush = new SolidColorBrush(Color.FromArgb("#FF4E4E"));
            }

            return brush;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
