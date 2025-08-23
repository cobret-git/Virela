using System.Windows;
using System.Windows.Controls.Primitives;

namespace Virela.Core.Controls
{
    public class VrlToggleButton : ToggleButton
    {
        #region Constructors
        static VrlToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VrlToggleButton), new FrameworkPropertyMetadata(typeof(VrlToggleButton)));
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(VrlToggleButton),
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
