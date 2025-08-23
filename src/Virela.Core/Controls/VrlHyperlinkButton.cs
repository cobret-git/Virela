using System.Diagnostics;
using System.Windows;

namespace Virela.Core.Controls
{
    public class VrlHyperlinkButton : VrlButton
    {
        #region Constructors
        static VrlHyperlinkButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VrlHyperlinkButton), new FrameworkPropertyMetadata(typeof(VrlHyperlinkButton)));
        }
        public VrlHyperlinkButton()
        {
            Click += OnClick;
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty NavigateUriProperty =
            DependencyProperty.Register(
                "NavigateUri",
                typeof(Uri),
                typeof(VrlHyperlinkButton),
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
