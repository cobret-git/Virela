using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Virela.Core.Controls
{
    public class VrlButton : Button
    {
        #region Constructors
        static VrlButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VrlButton), new FrameworkPropertyMetadata(typeof(VrlButton)));
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(VrlButton),
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
