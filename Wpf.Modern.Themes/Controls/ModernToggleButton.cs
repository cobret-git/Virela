using System.Windows;
using System.Windows.Controls.Primitives;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernToggleButton : ToggleButton
    {
        #region Constructors
        static ModernToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernToggleButton), new FrameworkPropertyMetadata(typeof(ModernToggleButton)));
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(ModernToggleButton),
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
