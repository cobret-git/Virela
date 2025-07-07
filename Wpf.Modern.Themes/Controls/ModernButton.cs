using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernButton : Button
    {
        #region Constructors
        static ModernButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernButton), new FrameworkPropertyMetadata(typeof(ModernButton)));
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(ModernButton),
                new PropertyMetadata(new CornerRadius(0))); // Default corner radius value
        #endregion

        #region Properties
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        #endregion
    }
}
