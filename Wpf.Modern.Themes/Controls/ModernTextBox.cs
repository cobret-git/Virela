using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernTextBox : TextBox
    {
        #region Constructors
        static ModernTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernTextBox), new FrameworkPropertyMetadata(typeof(ModernTextBox)));
        }
        public ModernTextBox()
        {
            // Subscribe to events to handle placeholder visibility
            GotFocus += OnGotFocus;
            LostFocus += OnLostFocus;
            TextChanged += OnTextChanged;

            // Set initial placeholder visibility
            Loaded += (s, e) => UpdatePlaceholderVisibility();
        }
        #endregion

        #region DependencyProperties
        // Placeholder text property
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                "Placeholder",
                typeof(string),
                typeof(ModernTextBox),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        // Placeholder foreground color property
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.Register(
                "PlaceholderForeground",
                typeof(Brush),
                typeof(ModernTextBox),
                new PropertyMetadata(Brushes.Gray));

        // Corner radius property
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(ModernTextBox),
                new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the placeholder text displayed when the TextBox is empty
        /// </summary>
        [Bindable(true), Description("Gets or sets the placeholder text displayed when the TextBox is empty")]
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// Gets or sets the foreground color of the placeholder text
        /// </summary>
        [Bindable(true), Description("Gets or sets the foreground color of the placeholder text")]
        public Brush PlaceholderForeground
        {
            get { return (Brush)GetValue(PlaceholderForegroundProperty); }
            set { SetValue(PlaceholderForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the corner radius of the TextBox
        /// </summary>
        [Bindable(true), Description("Gets or sets the corner radius of the TextBox")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        #endregion

        #region Handlers
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdatePlaceholderVisibility();
        }
        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernTextBox textBox)
            {
                textBox.UpdatePlaceholderVisibility();
            }
        }
        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }
        #endregion

        #region Helpers
        private void UpdatePlaceholderVisibility()
        {
            // The placeholder visibility will be handled in the control template
            // This method ensures the visual state is updated when needed
            InvalidateVisual();
        }        
        #endregion
    }
}
