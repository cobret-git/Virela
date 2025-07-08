using System.Windows;
using System.Windows.Input;

namespace Wpf.Modern.Themes.Controls.Helpers
{
    public static class KeyboardNavigationHelper
    {
        public static readonly DependencyProperty IsKeyboardFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsKeyboardFocused",
                typeof(bool),
                typeof(KeyboardNavigationHelper),
                new PropertyMetadata(false));

        public static bool GetIsKeyboardFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsKeyboardFocusedProperty);
        }

        public static void SetIsKeyboardFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsKeyboardFocusedProperty, value);
        }

        public static readonly DependencyProperty EnableKeyboardFocusTrackingProperty =
            DependencyProperty.RegisterAttached(
                "EnableKeyboardFocusTracking",
                typeof(bool),
                typeof(KeyboardNavigationHelper),
                new PropertyMetadata(false, OnEnableKeyboardFocusTrackingChanged));

        public static bool GetEnableKeyboardFocusTracking(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableKeyboardFocusTrackingProperty);
        }

        public static void SetEnableKeyboardFocusTracking(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableKeyboardFocusTrackingProperty, value);
        }

        private static void OnEnableKeyboardFocusTrackingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if ((bool)e.NewValue)
                {
                    element.PreviewMouseDown += OnPreviewMouseDown;
                    element.PreviewKeyDown += OnPreviewKeyDown;
                    element.GotKeyboardFocus += OnGotKeyboardFocus;
                    element.LostKeyboardFocus += OnLostKeyboardFocus;
                }
                else
                {
                    element.PreviewMouseDown -= OnPreviewMouseDown;
                    element.PreviewKeyDown -= OnPreviewKeyDown;
                    element.GotKeyboardFocus -= OnGotKeyboardFocus;
                    element.LostKeyboardFocus -= OnLostKeyboardFocus;
                }
            }
        }

        private static bool _lastInputWasKeyboard = false;

        private static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _lastInputWasKeyboard = false;
        }

        private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                _lastInputWasKeyboard = true;
            }
        }

        private static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is DependencyObject obj)
            {
                SetIsKeyboardFocused(obj, _lastInputWasKeyboard);
            }
        }

        private static void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is DependencyObject obj)
            {
                SetIsKeyboardFocused(obj, false);
            }
        }
    }
}
