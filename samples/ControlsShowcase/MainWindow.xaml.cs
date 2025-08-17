using System.Windows;
using Virela.GitHub.Components.Enums;
using Virela.GitHub.Services;

namespace ControlsShowcase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private readonly GithubThemeManager themeManager;
        #endregion

        #region Constructors
        public MainWindow()
        {
            this.themeManager = new GithubThemeManager();
            themeManager.ApplyTheme(GitHubPalette.Light);
            this.DataContext = this;
            InitializeComponent();
        }
        #endregion
        public GitHubPalette ActivePalette { get => themeManager.CurrentPalette; set { themeManager.ApplyTheme(value); } }
    }
}