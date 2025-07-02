using System.Windows;
using System.Windows.Controls;
using Test.Views.Pages;
using Wpf.Modern.Themes.Services;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private readonly ThemeManager themeManager;
        #endregion

        #region Constructors
        public MainWindow()
        {
            themeManager = new ThemeManager();
            SelectedTheme = WpfTheme.GithubDark; // Set default theme
            this.DataContext = this;
            InitializeComponent();
            MainFrame.Navigate(new ButtonPage());
        }
        #endregion

        #region Properties
        public WpfTheme[] Themes { get; } = Enum.GetValues<WpfTheme>();
        public WpfTheme SelectedTheme { get => themeManager.CurrentTheme; set { themeManager.ApplyTheme(value); } }
        #endregion

        #region Methods
        private void NavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NavigationListBox.SelectedItem is ListBoxItem selectedItem)
            {
                var pageType = selectedItem.Tag as Type;
                if (pageType != null)
                {
                    // Navigate the frame to the selected page
                    var page = (Page)Activator.CreateInstance(pageType);
                    MainFrame.Navigate(page);
                }
            }
        }
        #endregion
    }
}