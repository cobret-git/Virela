using System.Windows;
using System.Windows.Media;

namespace Virela.Core.Controls.Helpers
{
    public class VrlCommonState
    {
        #region Dependency Properties
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
            DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DisabledBackgroundBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DisabledOpacityProperty =
            DependencyProperty.RegisterAttached("DisabledOpacity", typeof(double), typeof(VrlCommonState), new FrameworkPropertyMetadata(1.0));

        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.RegisterAttached("DisabledBorderBrush", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(VrlCommonState), new FrameworkPropertyMetadata(null));
        #endregion

        #region Get Methods
        public static Brush GetMouseOverBackground(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.MouseOverBackgroundProperty);
        public static Brush GetMouseOverForeground(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.MouseOverForegroundProperty);
        public static Brush GetMouseOverBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.MouseOverBorderBrushProperty);
        public static Brush GetPressedBackground(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.PressedBackgroundProperty);
        public static Brush GetPressedForeground(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.PressedForegroundProperty);
        public static Brush GetPressedBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.PressedBorderBrushProperty);
        public static Brush GetDisabledBackgroundBrush(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.DisabledBackgroundBrushProperty);
        public static double GetDisabledOpacity(DependencyObject element) => (double)element.GetValue(VrlCommonState.DisabledOpacityProperty);
        public static Brush GetDisabledBorderBrush(DependencyObject element) => (Brush)element.GetValue(VrlCommonState.DisabledBorderBrushProperty);
        #endregion

        #region Set Methods
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
