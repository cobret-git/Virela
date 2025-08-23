using System.Windows;
using System.Windows.Controls;

namespace ControlsShowcase.Pages
{
    /// <summary>
    /// Interaction logic for ButtonsPage.xaml
    /// </summary>
    public partial class ButtonsPage : UserControl
    {
        public ButtonsPage()
        {
            InitializeComponent();
        }

        private void StandardButtonChecbox_Checked(object sender, RoutedEventArgs e) => ChangeStandardButtonStatement();
        private void StandardButtonChecbox_Unchecked(object sender, RoutedEventArgs e) => ChangeStandardButtonStatement();
        private void ColoredButtonChecbox_Checked(object sender, RoutedEventArgs e) => ChangeColoredButtonStatement();
        private void ColoredButtonChecbox_Unchecked(object sender, RoutedEventArgs e) => ChangeColoredButtonStatement();

        private void ChangeStandardButtonStatement()
        {
            if (StandardButton == null || StandardButtonCode == null) return;
            StandardButton.IsEnabled = StandardButtonChecbox.IsChecked == true;
            StandardButtonCode.Text = StandardButtonChecbox.IsChecked == true
                ? "<virela:VrlButton Content=\"Standard Button\" HorizontalAlignment=\"Left\"/>"
                : "<virela:VrlButton Content=\"Standard Button\" HorizontalAlignment=\"Left\" IsEnabled=\"False\"/>";
        }
        private void ChangeColoredButtonStatement()
        {
            if (ColoredButton == null || ColoredButtonCode == null) return;
            ColoredButton.IsEnabled = ColoredButtonChecbox.IsChecked == true;
            ColoredButtonCode.Text = ColoredButtonChecbox.IsChecked == true
                ? "<virela:VrlButton x:Name=\"ColoredButton\" Grid.Column=\"0\" Content=\"Colored button\" HorizontalAlignment=\"Left\" \r\n" +
                "                    Background=\"#6d4aff\" Foreground=\"#fff\" BorderThickness=\"0\"\r\n" +
                "                    virela:VrlCommonState.MouseOverBackground=\"#7c5cff\" \r\n" +
                "                    virela:VrlCommonState.MouseOverForeground=\"#ffff\"\r\n" +
                "                    virela:VrlCommonState.PressedBackground=\"#8a6eff\"\r\n" +
                "                    virela:VrlCommonState.PressedForeground=\"#fff\"\r\n" +
                "                    virela:VrlCommonState.DisabledBackground=\"#8a8797\"/>"
                : "<virela:VrlButton x:Name=\"ColoredButton\" Grid.Column=\"0\" Content=\"Colored button\" HorizontalAlignment=\"Left\" \r\n" +
                "                    Background=\"#6d4aff\" Foreground=\"#fff\" BorderThickness=\"0\"\r\n" +
                "                    virela:VrlCommonState.MouseOverBackground=\"#7c5cff\" \r\n" +
                "                    virela:VrlCommonState.MouseOverForeground=\"#ffff\"\r\n" +
                "                    virela:VrlCommonState.PressedBackground=\"#8a6eff\"\r\n" +
                "                    virela:VrlCommonState.PressedForeground=\"#fff\"\r\n" +
                "                    virela:VrlCommonState.DisabledBackground=\"#8a8797\"\r\n" +
                "                    IsEnabled=\"False\"/>";
        }
    }
}
