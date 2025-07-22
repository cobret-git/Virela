using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Wpf.Modern.Themes.Converters
{
    public class BottomRightCornerRadiusDoubleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CornerRadius cornerRadius)
            {
                return cornerRadius.BottomRight;
            }
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
