using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernToggleSwitch : ToggleButton
    {
        #region Consts
        #endregion

        #region Fields
        private static readonly Type ctrlType = typeof(ModernToggleSwitch);
        private FrameworkElement? thumb;
        #endregion

        #region Constructors
        static ModernToggleSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernToggleSwitch), new FrameworkPropertyMetadata(typeof(ModernToggleSwitch)));
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty ContentPlacementProperty =
            DependencyProperty.Register(nameof(ContentPlacement), typeof(ToggleSwitchContentPlacement), ctrlType,
                new PropertyMetadata(ToggleSwitchContentPlacement.Left));

        public static readonly DependencyProperty CheckedContentProperty =
           DependencyProperty.Register(nameof(CheckedContent), typeof(string), ctrlType,
               new PropertyMetadata(null));

        public static readonly DependencyProperty CheckedContentTemplateProperty =
            DependencyProperty.Register(nameof(CheckedContentTemplate), typeof(DataTemplate), ctrlType,
                new PropertyMetadata(null));

        public static readonly DependencyProperty UncheckedContentProperty =
            DependencyProperty.Register(nameof(UncheckedContent), typeof(string), ctrlType,
                new PropertyMetadata(null));

        public static readonly DependencyProperty UncheckedContentTemplateProperty =
            DependencyProperty.Register(nameof(UncheckedContentTemplate), typeof(DataTemplate), ctrlType,
                new PropertyMetadata(null));
        #endregion

        #region Properties
        [Bindable(true), Description("Gets or sets the Switch content for checked state."), Category(nameof(ModernToggleSwitch))]
        public object CheckedContent
        {
            get { return GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }

        [Bindable(true), Description("Gets or sets the template that defines the appearance of the control's checked state content.")]
        public DataTemplate CheckedContentTemplate
        {
            get => (DataTemplate)this.GetValue(CheckedContentTemplateProperty);
            set => this.SetValue(CheckedContentTemplateProperty, (object)value);
        }

        [Bindable(true), Description("Gets or sets the Switch content for Unchecked state."), Category(nameof(ModernToggleSwitch))]
        public object UncheckedContent
        {
            get { return GetValue(UncheckedContentProperty); }
            set { SetValue(UncheckedContentProperty, value); }
        }

        [Bindable(true), Description("Gets or sets the template that defines the appearance of the control's unchecked state content")]
        public DataTemplate UncheckedContentTemplate
        {
            get => (DataTemplate)this.GetValue(UncheckedContentTemplateProperty);
            set => this.SetValue(UncheckedContentTemplateProperty, (object)value);
        }

        [Bindable(true), Description("Gets or sets the position of the content area of the toggle switch button.")]
        public ToggleSwitchContentPlacement ContentPlacement
        {
            get => (ToggleSwitchContentPlacement)this.GetValue(ContentPlacementProperty);
            set => this.SetValue(ContentPlacementProperty, (object)value);
        }
        #endregion

        #region Handerls

        /// <summary>
        /// Invoked whenever application code or internal processes
        /// (such as a rebuilding layout pass) call.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.thumb = this.GetTemplateChild("PART_Thumb") as FrameworkElement;
            if (this.thumb == null) return;
            if (IsChecked == true) this.thumb.HorizontalAlignment = HorizontalAlignment.Right;
            else
            {
                if (!this.IsThreeState) return;
                if (IsChecked.HasValue) return;
                this.thumb.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }
        #endregion
    }
}
