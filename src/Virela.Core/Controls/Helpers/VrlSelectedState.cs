using System.Windows;
using System.Windows.Media;

namespace Virela.Core.Controls.Helpers
{
    public class VrlSelectedState
    {
        #region Dependency Properties
        public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
            DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DisabledBackgroundBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DisabledOpacityProperty =
            DependencyProperty.RegisterAttached("DisabledOpacity", typeof(double), typeof(VrlSelectedState), new FrameworkPropertyMetadata(1.0));

        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBorderBrush", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(VrlSelectedState), new FrameworkPropertyMetadata(null));
        #endregion

        #region Get Methods
        public static Brush GetBackground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.BackgroundProperty);
        public static Brush GetForeground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.ForegroundProperty);
        public static Brush GetBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.BorderBrushProperty);
        public static Brush GetMouseOverBackground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.MouseOverBackgroundProperty);
        public static Brush GetMouseOverForeground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.MouseOverForegroundProperty);
        public static Brush GetMouseOverBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.MouseOverBorderBrushProperty);
        public static Brush GetPressedBackground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.PressedBackgroundProperty);
        public static Brush GetPressedForeground(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.PressedForegroundProperty);
        public static Brush GetPressedBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.PressedBorderBrushProperty);
        public static Brush GetDisabledBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.DisabledBackgroundBrushProperty);
        public static double GetDisabledOpacity(DependencyObject element) => (double)element.GetValue(VrlSelectedState.DisabledOpacityProperty);
        public static Brush GetDisabledBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlSelectedState.DisabledBorderBrushProperty);
        #endregion

        #region Set Methods
        public static void SetBackground(DependencyObject element, Brush value) => element.SetValue(BackgroundProperty, value);
        public static void SetForeground(DependencyObject element, Brush value) => element.SetValue(ForegroundProperty, value);
        public static void SetBorderBrush(DependencyObject element, Brush value) => element.SetValue(BorderBrushProperty, value);
        public static void SetMouseOverBackground(DependencyObject element, Brush value) => element.SetValue(MouseOverBackgroundProperty, value);
        public static void SetMouseOverForeground(DependencyObject element, Brush value) => element.SetValue(MouseOverForegroundProperty, value);
        public static void SetMouseOverBorderBrush(DependencyObject element, Brush value) => element.SetValue(MouseOverBorderBrushProperty, value);
        public static void SetPressedBackground(DependencyObject element, Brush value) => element.SetValue(PressedBackgroundProperty, value);
        public static void SetPressedForeground(DependencyObject element, Brush value) => element.SetValue(PressedForegroundProperty, value);
        public static void SetPressedBorderBrush(DependencyObject element, Brush value) => element.SetValue(PressedBorderBrushProperty, value);
        public static void SetDisabledBackgroundBrush(DependencyObject element, Brush value) => element.SetValue(DisabledBackgroundBrushProperty, value);
        public static void SetDisabledOpacity(DependencyObject element, double value) => element.SetValue(DisabledOpacityProperty, value);
        public static void SetDisabledBorderBrush(DependencyObject element, Brush value) => element.SetValue(DisabledBorderBrushProperty, value);
        #endregion
    }
}
