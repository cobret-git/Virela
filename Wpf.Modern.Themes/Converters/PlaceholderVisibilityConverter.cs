using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Wpf.Modern.Themes.Converters;

/// <summary>
/// Converter that determines when to show/hide the placeholder text
/// </summary>
public class PlaceholderVisibilityConverter : IMultiValueConverter
{
    public static readonly PlaceholderVisibilityConverter Instance = new PlaceholderVisibilityConverter();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        // values[0] = Text property
        // values[1] = IsFocused property  
        // values[2] = Placeholder property

        if (values == null || values.Length < 3) return Visibility.Collapsed;

        string text = values[0] as string ?? string.Empty;
        bool isFocused = values[1] is bool focused && focused;
        string placeholder = values[2] as string ?? string.Empty;

        // Show placeholder if:
        // 1. There's a placeholder text defined
        // 2. The textbox is empty
        // 3. The textbox is not focused (optional - you can remove this condition if you want placeholder visible while typing)
            
        bool shouldShowPlaceholder = !string.IsNullOrEmpty(placeholder) && 
                                     string.IsNullOrEmpty(text) && 
                                     !isFocused;

        return shouldShowPlaceholder ? Visibility.Visible : Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}