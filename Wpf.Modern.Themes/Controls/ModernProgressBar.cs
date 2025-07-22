using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernProgressBar : ProgressBar
    {
        #region Constructors
        static ModernProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernProgressBar), new FrameworkPropertyMetadata(typeof(ModernProgressBar)));
        }
        public ModernProgressBar()
        {
        }
        #endregion

        #region DependencyProperties
        public static readonly DependencyProperty ShowPausedProperty =
            DependencyProperty.Register("ShowPaused", typeof(bool), typeof(ModernProgressBar),
                new PropertyMetadata(false));

        public static readonly DependencyProperty ShowErrorProperty =
            DependencyProperty.Register("ShowError", typeof(bool), typeof(ModernProgressBar),
                new PropertyMetadata(false));

        public static readonly DependencyProperty PausedBrushProperty =
            DependencyProperty.Register("PausedBrush", typeof(Brush), typeof(ModernProgressBar),
                new PropertyMetadata(new SolidColorBrush(Colors.Orange)));

        public static readonly DependencyProperty ErrorBrushProperty =
            DependencyProperty.Register("ErrorBrush", typeof(Brush), typeof(ModernProgressBar),
                new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ModernProgressBar),
                new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ProgressBarTrackCornerRadiusProperty =
            DependencyProperty.Register("ProgressBarTrackCornerRadius", typeof(CornerRadius), typeof(ModernProgressBar),
                new PropertyMetadata(new CornerRadius(1.5)));
        #endregion

        #region Properties
        [Bindable(true)]
        public bool ShowPaused
        {
            get { return (bool)GetValue(ShowPausedProperty); }
            set { SetValue(ShowPausedProperty, value); }
        }

        [Bindable(true)]
        public bool ShowError
        {
            get { return (bool)GetValue(ShowErrorProperty); }
            set { SetValue(ShowErrorProperty, value); }
        }

        public Brush PausedBrush
        {
            get { return (Brush)GetValue(PausedBrushProperty); }
            set { SetValue(PausedBrushProperty, value); }
        }

        public Brush ErrorBrush
        {
            get { return (Brush)GetValue(ErrorBrushProperty); }
            set { SetValue(ErrorBrushProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public CornerRadius ProgressBarTrackCornerRadius
        {
            get { return (CornerRadius)GetValue(ProgressBarTrackCornerRadiusProperty); }
            set { SetValue(ProgressBarTrackCornerRadiusProperty, value); }
        }
        #endregion
    }
}
