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
        public static readonly DependencyProperty ReadOnlyBrushProperty = DependencyProperty.RegisterAttached("ReadOnlyBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty ReadOnlyBackgroundBrushProperty = DependencyProperty.RegisterAttached("ReadOnlyBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBrushProperty = DependencyProperty.RegisterAttached("DisabledBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyProperty.RegisterAttached("DisabledBorderBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
        public static readonly DependencyProperty DisabledForegroundBrushProperty = DependencyProperty.RegisterAttached("DisabledForegroundBrush", typeof(Brush), typeof(ThemeHelper), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
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
        public static Brush GetReadOnlyBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.ReadOnlyBrushProperty);
        public static Brush GetReadOnlyBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.ReadOnlyBackgroundBrushProperty);
        public static Brush GetDisabledBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBrushProperty);
        public static Brush GetDisabledBackgroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBackgroundBrushProperty);
        public static Brush GetDisabledForegroundBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledForegroundBrushProperty);
        public static Brush GetDisabledBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(ThemeHelper.DisabledBorderBrushProperty);
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
        public static void SetReadOnlyBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.ReadOnlyBrushProperty, (object)value);
        public static void SetReadOnlyBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.ReadOnlyBackgroundBrushProperty, (object)value);
        public static void SetDisabledBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledBrushProperty, (object)value);
        public static void SetDisabledBackgroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledBackgroundBrushProperty, (object)value);
        public static void SetDisabledForegroundBrush(DependencyObject obj, Brush value) => obj.SetValue(ThemeHelper.DisabledForegroundBrushProperty, (object)value);
        #endregion
    }
}
