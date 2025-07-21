using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernNumericBox : TextBox
    {
        #region Fields
        private bool _isUpdatingText = false;
        private bool _isUpdatingValue = false;
        #endregion

        #region Constructors
        static ModernNumericBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernNumericBox), new FrameworkPropertyMetadata(typeof(ModernNumericBox)));
        }
        public ModernNumericBox()
        {
            // Subscribe to events
            TextChanged += OnTextChanged;
            PreviewTextInput += OnPreviewTextInput;
            PreviewKeyDown += OnPreviewKeyDown;
            LostFocus += OnLostFocus;
            // Set initial value
            UpdateTextFromValue();
        }
        #endregion

        #region DependencyProperties
        // Value property (the main numeric value)
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(double?),
                typeof(ModernNumericBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

        // Minimum value property
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(
                "Minimum",
                typeof(double?),
                typeof(ModernNumericBox),
                new PropertyMetadata(null, OnMinMaxChanged));

        // Maximum value property
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                "Maximum",
                typeof(double?),
                typeof(ModernNumericBox),
                new PropertyMetadata(null, OnMinMaxChanged));

        // IsInteger property
        public static readonly DependencyProperty IsIntegerProperty =
            DependencyProperty.Register(
                "IsInteger",
                typeof(bool),
                typeof(ModernNumericBox),
                new PropertyMetadata(false, OnIsIntegerChanged));

        // HideTrailingZeroes property
        public static readonly DependencyProperty HideTrailingZeroesProperty =
            DependencyProperty.Register(
                "HideTrailingZeroes",
                typeof(bool),
                typeof(ModernNumericBox),
                new PropertyMetadata(false, OnHideTrailingZeroesChanged));

        // DecimalPlaces property
        public static readonly DependencyProperty DecimalPlacesProperty =
            DependencyProperty.Register(
                "DecimalPlaces",
                typeof(int),
                typeof(ModernNumericBox),
                new PropertyMetadata(2, OnDecimalPlacesChanged));

        // AllowNegative property
        public static readonly DependencyProperty AllowNegativeProperty =
            DependencyProperty.Register(
                "AllowNegative",
                typeof(bool),
                typeof(ModernNumericBox),
                new PropertyMetadata(true));

        // Placeholder text property
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                "Placeholder",
                typeof(string),
                typeof(ModernNumericBox),
                new PropertyMetadata(string.Empty));

        // Placeholder foreground color property
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.Register(
                "PlaceholderForeground",
                typeof(Brush),
                typeof(ModernNumericBox),
                new PropertyMetadata(Brushes.Gray));

        // Corner radius property
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(ModernNumericBox),
                new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region Properties
        /// <summary>
        /// Hide the Text property from designer and binding (use Value instead)
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Gets or sets the numeric value of the control
        /// </summary>
        public double? Value
        {
            get { return (double?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum allowed value
        /// </summary>
        public double? Minimum
        {
            get { return (double?)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum allowed value
        /// </summary>
        public double? Maximum
        {
            get { return (double?)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether only integer values are allowed
        /// </summary>
        public bool IsInteger
        {
            get { return (bool)GetValue(IsIntegerProperty); }
            set { SetValue(IsIntegerProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether trailing zeroes should be hidden
        /// </summary>
        public bool HideTrailingZeroes
        {
            get { return (bool)GetValue(HideTrailingZeroesProperty); }
            set { SetValue(HideTrailingZeroesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the number of decimal places (when not hiding trailing zeroes)
        /// </summary>
        public int DecimalPlaces
        {
            get { return (int)GetValue(DecimalPlacesProperty); }
            set { SetValue(DecimalPlacesProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether negative values are allowed
        /// </summary>
        public bool AllowNegative
        {
            get { return (bool)GetValue(AllowNegativeProperty); }
            set { SetValue(AllowNegativeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the placeholder text
        /// </summary>
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// Gets or sets the placeholder foreground brush
        /// </summary>
        public Brush PlaceholderForeground
        {
            get { return (Brush)GetValue(PlaceholderForegroundProperty); }
            set { SetValue(PlaceholderForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the corner radius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        #endregion

        #region Handlers
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernNumericBox numericBox && !numericBox._isUpdatingValue)
            {
                numericBox.UpdateTextFromValue();
                numericBox.ValidateValue();
            }
        }
        private static void OnMinMaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernNumericBox numericBox)
            {
                numericBox.ValidateValue();
            }
        }
        private static void OnIsIntegerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernNumericBox numericBox)
            {
                numericBox.UpdateTextFromValue();
                numericBox.ValidateValue();
            }
        }
        private static void OnHideTrailingZeroesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernNumericBox numericBox)
            {
                numericBox.UpdateTextFromValue();
            }
        }
        private static void OnDecimalPlacesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ModernNumericBox numericBox)
            {
                numericBox.UpdateTextFromValue();
            }
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isUpdatingText)
            {
                UpdateValueFromText();
            }
        }
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidInput(e.Text);
        }
        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Allow control keys
            if (e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Tab ||
                e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Home || e.Key == Key.End)
            {
                return;
            }

            // Allow Ctrl combinations (copy, paste, etc.)
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                return;
            }
        }
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            UpdateTextFromValue(); // Reformat the display
        }
        #endregion

        #region Private Methods
        private bool IsValidInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var negativeSign = CultureInfo.CurrentCulture.NumberFormat.NegativeSign;

            foreach (char c in input)
            {
                // Allow digits
                if (char.IsDigit(c))
                    continue;

                // Allow decimal separator if not integer mode and not already present
                if (!IsInteger && c.ToString() == decimalSeparator && !Text.Contains(decimalSeparator))
                    continue;

                // Allow negative sign if allowed, at the beginning, and not already present
                if (AllowNegative && c.ToString() == negativeSign && CaretIndex == 0 && !Text.Contains(negativeSign))
                    continue;

                return false;
            }

            return true;
        }
        private void UpdateValueFromText()
        {
            _isUpdatingValue = true;

            try
            {
                if (string.IsNullOrWhiteSpace(Text))
                {
                    Value = null;
                }
                else if (double.TryParse(Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double result))
                {
                    // Apply integer constraint
                    if (IsInteger)
                    {
                        result = Math.Round(result, 0);
                    }

                    // Apply min/max constraints
                    if (Minimum.HasValue && result < Minimum.Value)
                    {
                        result = Minimum.Value;
                    }
                    if (Maximum.HasValue && result > Maximum.Value)
                    {
                        result = Maximum.Value;
                    }

                    Value = result;
                }
            }
            finally
            {
                _isUpdatingValue = false;
            }

            ValidateValue();
        }
        private void UpdateTextFromValue()
        {
            _isUpdatingText = true;

            try
            {
                if (!Value.HasValue)
                {
                    Text = string.Empty;
                }
                else
                {
                    string format;
                    if (IsInteger)
                    {
                        format = "F0";
                    }
                    else if (HideTrailingZeroes)
                    {
                        format = "G";
                    }
                    else
                    {
                        format = $"F{DecimalPlaces}";
                    }

                    Text = Value.Value.ToString(format, CultureInfo.CurrentCulture);
                }
            }
            finally
            {
                _isUpdatingText = false;
            }
        }
        private void ValidateValue()
        {
            //if (!Value.HasValue)
            //{
            //    ValidationState = ValidationState.None;
            //    ValidationMessage = string.Empty;
            //    return;
            //}

            //var value = Value.Value;

            //// Check minimum constraint
            //if (Minimum.HasValue && value < Minimum.Value)
            //{
            //    ValidationState = ValidationState.Invalid;
            //    ValidationMessage = $"Value must be greater than or equal to {Minimum.Value}";
            //    return;
            //}

            //// Check maximum constraint
            //if (Maximum.HasValue && value > Maximum.Value)
            //{
            //    ValidationState = ValidationState.Invalid;
            //    ValidationMessage = $"Value must be less than or equal to {Maximum.Value}";
            //    return;
            //}

            //// Check integer constraint
            //if (IsInteger && value != Math.Round(value, 0))
            //{
            //    ValidationState = ValidationState.Invalid;
            //    ValidationMessage = "Only integer values are allowed";
            //    return;
            //}

            //// All validations passed
            //ValidationState = ValidationState.Valid;
            //ValidationMessage = "Valid numeric value";
        }
        #endregion
    }
}
