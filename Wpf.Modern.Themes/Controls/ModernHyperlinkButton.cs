using System.Diagnostics;
using System.Windows;

namespace Wpf.Modern.Themes.Controls
{
    public class ModernHyperlinkButton : ModernButton
    {
        #region Constructors
        static ModernHyperlinkButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernHyperlinkButton), new FrameworkPropertyMetadata(typeof(ModernHyperlinkButton)));
        }
        public ModernHyperlinkButton()
        {
            Click += OnClick;
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty NavigateUriProperty =
            DependencyProperty.Register(
                "NavigateUri",
                typeof(Uri),
                typeof(ModernHyperlinkButton),
                new PropertyMetadata(null));
        #endregion

        #region Properties
        public Uri NavigateUri
        {
            get { return (Uri)GetValue(NavigateUriProperty); }
            set { SetValue(NavigateUriProperty, value); }
        }
        #endregion

        #region Handlers
        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigateUri != null)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = NavigateUri.ToString(),
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    // Handle exception as needed (log, show message, etc.)
                    Debug.WriteLine($"Unable to open link: {ex.Message}", "Error");
                }
            }
        }
        #endregion
    }
}
