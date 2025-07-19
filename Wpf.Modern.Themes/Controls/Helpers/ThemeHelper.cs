using System.Windows;
using System.Windows.Media;

namespace Wpf.Modern.Themes.Controls.Helpers
{
    public class ThemeHelper
    {
        #region Dependency Properties
        public static readonly DependencyProperty MouseOverBrushProperty = DependencyProperty.RegisterAttached("MouseOverBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty MouseOverBackgroundBrushProperty = DependencyProperty.RegisterAttached("MouseOverBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty PressedBrushProperty = DependencyProperty.RegisterAttached("PressedBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty PressedBackgroundBrushProperty = DependencyProperty.RegisterAttached("PressedBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty FocusBrushProperty = DependencyProperty.RegisterAttached("FocusBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty FocusBackgroundBrushProperty = DependencyProperty.RegisterAttached("FocusBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedBrushProperty = DependencyProperty.RegisterAttached("CheckedBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedBackgroundBrushProperty = DependencyProperty.RegisterAttached("CheckedBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedMouseOverBackgroundBrushProperty = DependencyProperty.RegisterAttached("CheckedMouseOverBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedPressedBackgroundBrushProperty = DependencyProperty.RegisterAttached("CheckedPressedBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedBorderBrushProperty = DependencyProperty.RegisterAttached("CheckedBorderBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty CheckedDisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached("CheckedDisabledBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty ReadOnlyBrushProperty = DependencyProperty.RegisterAttached("ReadOnlyBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty ReadOnlyBackgroundBrushProperty = DependencyProperty.RegisterAttached("ReadOnlyBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBrushProperty = DependencyProperty.RegisterAttached("DisabledBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyProperty.RegisterAttached("DisabledBorderBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledForegroundBrushProperty = DependencyProperty.RegisterAttached("DisabledForegroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        
        public static readonly DependencyProperty InvalidBrushProperty = DependencyProperty.RegisterAttached("InvalidBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidMouseOverBrushProperty = DependencyProperty.RegisterAttached("InvalidMouseOverBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidDisabledBrushProperty = DependencyProperty.RegisterAttached("InvalidDisabledBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidBackgroundBrushProperty = DependencyProperty.RegisterAttached("InvalidBackgroundBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidMouseOverBackgroundBrushProperty = DependencyProperty.RegisterAttached("InvalidMouseOverBackgroundBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidDisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached("InvalidDisabledBackgroundBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidBorderBrushProperty = DependencyProperty.RegisterAttached("InvalidBorderBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidMouseOverBorderBrushProperty = DependencyProperty.RegisterAttached("InvalidMouseOverBorderBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty InvalidDisabledBorderBrushProperty = DependencyProperty.RegisterAttached("InvalidDisabledBorderBrush", typeof(Brush), typeof(ThemeHelper), new FrameworkPropertyMetadata(null));
        #endregion

        #region Constructors
        public ThemeHelper()
        {
        }
        #endregion

        #region Getters
        public static Brush GetMouseOverBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.MouseOverBrushProperty);
        public static Brush GetMouseOverBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.MouseOverBackgroundBrushProperty);
        public static Brush GetMouseOverBorderBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.MouseOverBorderBrushProperty);
        public static Brush GetPressedBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.PressedBrushProperty);
        public static Brush GetPressedBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.PressedBackgroundBrushProperty);
        public static Brush GetPressedBorderBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.PressedBorderBrushProperty);
        public static Brush GetFocusBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.FocusBrushProperty);
        public static Brush GetFocusBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.FocusBrushProperty);
        public static Brush GetCheckedBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedBrushProperty);
        public static Brush GetCheckedBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedBackgroundBrushProperty);
        public static Brush GetCheckedMouseOverBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedMouseOverBackgroundBrushProperty);
        public static Brush GetCheckedPressedBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedPressedBackgroundBrushProperty);
        public static Brush GetCheckedDisabledBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedDisabledBackgroundBrushProperty);
        public static Brush GetCheckedBorderBrush(DependencyObject element) => (Brush)element.GetValue(ThemeHelper.CheckedBorderBrushProperty);
        public static Brush GetReadOnlyBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.ReadOnlyBrushProperty);
        public static Brush GetReadOnlyBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.ReadOnlyBackgroundBrushProperty);
        public static Brush GetDisabledBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBrushProperty);
        public static Brush GetDisabledBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBackgroundBrushProperty);
        public static Brush GetDisabledForegroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledForegroundBrushProperty);
        public static Brush GetDisabledBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBorderBrushProperty);
        
        public static Brush GetInvalidBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidBrushProperty);
        public static Brush GetInvalidMouseOverBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidMouseOverBrushProperty);
        public static Brush GetInvalidDisabledBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidDisabledBrushProperty);
        public static Brush GetInvalidBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidBackgroundBrushProperty);
        public static Brush GetInvalidMouseOverBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidMouseOverBackgroundBrushProperty);
        public static Brush GetInvalidDisabledBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidDisabledBackgroundBrushProperty);
        public static Brush GetInvalidBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidBorderBrushProperty);
        public static Brush GetInvalidMouseOverBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidMouseOverBorderBrushProperty);
        public static Brush GetInvalidDisabledBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.InvalidDisabledBorderBrushProperty);
        #endregion

        #region Setters
        public static void SetMouseOverBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.MouseOverBrushProperty, (object)value);
        public static void SetMouseOverBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.MouseOverBackgroundBrushProperty, (object)value);        
        public static void SetMouseOverBorderBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.MouseOverBorderBrushProperty, (object)value);        
        public static void SetPressedBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.PressedBrushProperty, (object)value);        
        public static void SetPressedBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.PressedBackgroundBrushProperty, (object)value);        
        public static void SetPressedBorderBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.PressedBorderBrushProperty, (object)value);        
        public static void SetFocusBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.FocusBrushProperty, (object)value);        
        public static void SetFocusBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.FocusBrushProperty, (object)value);        
        public static void SetCheckedBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedBrushProperty, (object)value);        
        public static void SetCheckedBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedBackgroundBrushProperty, (object)value);
        public static void SetCheckedMouseOverBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedMouseOverBackgroundBrushProperty, (object)value);
        public static void SetCheckedPressedBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedPressedBackgroundBrushProperty, (object)value);
        public static void SetCheckedDisabledBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedDisabledBackgroundBrushProperty, (object)value);
        public static void SetCheckedBorderBrush(DependencyObject element, Brush value) => element.SetValue(ThemeHelper.CheckedBorderBrushProperty, (object)value);
        public static void SetReadOnlyBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.ReadOnlyBrushProperty, (object)value);
        public static void SetReadOnlyBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.ReadOnlyBackgroundBrushProperty, (object)value);
        public static void SetDisabledBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledBrushProperty, (object)value);
        public static void SetDisabledBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledBackgroundBrushProperty, (object)value);
        public static void SetDisabledForegroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledForegroundBrushProperty, (object)value);
        
        public static void SetInvalidBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidBrushProperty, (object)value);
        public static void SetInvalidMouseOverBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidMouseOverBrushProperty, (object)value);
        public static void SetInvalidDisabledBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidDisabledBrushProperty, (object)value);
        public static void SetInvalidBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidBackgroundBrushProperty, (object)value);
        public static void SetInvalidMouseOverBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidMouseOverBackgroundBrushProperty, (object)value);
        public static void SetInvalidDisabledBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidDisabledBackgroundBrushProperty, (object)value);
        public static void SetInvalidBorderBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidBorderBrushProperty, (object)value);
        public static void SetInvalidMouseOverBorderBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidMouseOverBorderBrushProperty, (object)value);
        public static void SetInvalidDisabledBorderBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.InvalidDisabledBorderBrushProperty, (object)value);
        #endregion
    }
}
