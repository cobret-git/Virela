using System.Windows;
using System.Windows.Media;

namespace Virela.Core.Controls.Helpers
{
    public class VrlCheckedState
    {
        #region Dependency Properties
        // Base Properties
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        // MouseOver Properties
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
            DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        // Pressed Properties
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        // Focused Properties
        public static readonly DependencyProperty FocusedBackgroundProperty =
            DependencyProperty.RegisterAttached("FocusedBackground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FocusedForegroundProperty =
            DependencyProperty.RegisterAttached("FocusedForeground", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        // Disabled Properties
        public static readonly DependencyProperty DisabledBackgroundBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DisabledOpacityProperty =
            DependencyProperty.RegisterAttached("DisabledOpacity", typeof(double), typeof(VrlCheckedState), new FrameworkPropertyMetadata(1.0));

        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBorderBrush", typeof(Brush), typeof(VrlCheckedState), new FrameworkPropertyMetadata(null));
        #endregion

        #region Get Methods
        // Base Property Getters
        public static Brush GetBackground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.BackgroundProperty);
        public static Brush GetForeground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.ForegroundProperty);
        public static Brush GetBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.BorderBrushProperty);

        // MouseOver Property Getters
        public static Brush GetMouseOverBackground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.MouseOverBackgroundProperty);
        public static Brush GetMouseOverForeground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.MouseOverForegroundProperty);
        public static Brush GetMouseOverBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.MouseOverBorderBrushProperty);

        // Pressed Property Getters
        public static Brush GetPressedBackground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.PressedBackgroundProperty);
        public static Brush GetPressedForeground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.PressedForegroundProperty);
        public static Brush GetPressedBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.PressedBorderBrushProperty);

        // Focused Property Getters
        public static Brush GetFocusedBackground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.FocusedBackgroundProperty);
        public static Brush GetFocusedForeground(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.FocusedForegroundProperty);
        public static Brush GetFocusedBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.FocusedBorderBrushProperty);

        // Disabled Property Getters
        public static Brush GetDisabledBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.DisabledBackgroundBrushProperty);
        public static double GetDisabledOpacity(DependencyObject element) => (double)element.GetValue(VrlCheckedState.DisabledOpacityProperty);
        public static Brush GetDisabledBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCheckedState.DisabledBorderBrushProperty);
        #endregion

        #region Set Methods
        // Base Property Setters
        public static void SetBackground(DependencyObject element, Brush value) => element.SetValue(BackgroundProperty, value);
        public static void SetForeground(DependencyObject element, Brush value) => element.SetValue(ForegroundProperty, value);
        public static void SetBorderBrush(DependencyObject element, Brush value) => element.SetValue(BorderBrushProperty, value);

        // MouseOver Property Setters
        public static void SetMouseOverBackground(DependencyObject element, Brush value) => element.SetValue(MouseOverBackgroundProperty, value);
        public static void SetMouseOverForeground(DependencyObject element, Brush value) => element.SetValue(MouseOverForegroundProperty, value);
        public static void SetMouseOverBorderBrush(DependencyObject element, Brush value) => element.SetValue(MouseOverBorderBrushProperty, value);

        // Pressed Property Setters
        public static void SetPressedBackground(DependencyObject element, Brush value) => element.SetValue(PressedBackgroundProperty, value);
        public static void SetPressedForeground(DependencyObject element, Brush value) => element.SetValue(PressedForegroundProperty, value);
        public static void SetPressedBorderBrush(DependencyObject element, Brush value) => element.SetValue(PressedBorderBrushProperty, value);

        // Focused Property Setters
        public static void SetFocusedBackground(DependencyObject element, Brush value) => element.SetValue(FocusedBackgroundProperty, value);
        public static void SetFocusedForeground(DependencyObject element, Brush value) => element.SetValue(FocusedForegroundProperty, value);
        public static void SetFocusedBorderBrush(DependencyObject element, Brush value) => element.SetValue(FocusedBorderBrushProperty, value);

        // Disabled Property Setters
        public static void SetDisabledBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(DisabledBackgroundBrushProperty, value);
        public static void SetDisabledOpacity(DependencyObject element, double value) => element.SetValue(DisabledOpacityProperty, value);
        public static void SetDisabledBorderBrush(DependencyObject element, Brush value) => element.SetValue(DisabledBorderBrushProperty, value);
        #endregion
    }
}
