using System.Windows;
using Virela.GitHub.Components.Enums;
using Virela.GitHub.Components.EventArgs;

namespace Virela.GitHub.Services
{
    public class GithubThemeManager
    {
        #region Fields
        private readonly Dictionary<GitHubPalette, string> AvailableThemes = new()
        {
            { GitHubPalette.Dark, "pack://application:,,,/Virela.GitHub;component/Themes/DarkTheme.xaml" },
            { GitHubPalette.DarkHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/DarkHighContrastTheme.xaml" },
            { GitHubPalette.DarkColorblind, "pack://application:,,,/Virela.GitHub;component/Themes/DarkColorblindTheme.xaml" },
            { GitHubPalette.DarkColorblindHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/DarkColorblindHighContrastTheme.xaml" },
            { GitHubPalette.DarkTritanopia, "pack://application:,,,/Virela.GitHub;component/Themes/DarkTritanopiaTheme.xaml" },
            { GitHubPalette.DarkTritanopiaHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/DarkTritanopiaHighContrastTheme.xaml" },

            { GitHubPalette.Light, "pack://application:,,,/Virela.GitHub;component/Themes/LightTheme.xaml" },
            { GitHubPalette.LightHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/LightHighContrastTheme.xaml" },
            { GitHubPalette.LightColorblind, "pack://application:,,,/Virela.GitHub;component/Themes/LightColorblindTheme.xaml" },
            { GitHubPalette.LightColorblindHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/LightColorblindHighContrastTheme.xaml" },
            { GitHubPalette.LightTritanopia, "pack://application:,,,/Virela.GitHub;component/Themes/LightTritanopiaTheme.xaml" },
            { GitHubPalette.LightTritanopiaHighContrast, "pack://application:,,,/Virela.GitHub;component/Themes/LightTritanopiaHighContrastTheme.xaml" },
        };
        #endregion

        #region Consts
        private const string ThemeResourceKey = "CurrentThemeLibrary";
        #endregion

        #region Events
        public event EventHandler<PaletteChangedEventArgs>? ThemeChanged;
        #endregion

        #region Properties
        public GitHubPalette CurrentPalette { get; private set; }
        #endregion

        #region Methods
        public void ApplyTheme(GitHubPalette palette)
        {
            if (!AvailableThemes.ContainsKey(palette))
                throw new ArgumentException($"Theme '{palette}' is not available.");

            var app = Application.Current;
            var oldTheme = CurrentPalette;

            // Remove existing theme
            var existingTheme = app.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Contains(ThemeResourceKey));

            if (existingTheme != null)
            {
                app.Resources.MergedDictionaries.Remove(existingTheme);
            }

            // Add new theme
            var themeUri = new Uri(AvailableThemes[palette], UriKind.Absolute);
            var newTheme = new ResourceDictionary { Source = themeUri };
            newTheme[ThemeResourceKey] = palette;

            app.Resources.MergedDictionaries.Add(newTheme);

            CurrentPalette = palette;

            // Notify about theme change
            ThemeChanged?.Invoke(null, new PaletteChangedEventArgs(oldTheme, palette));

            // Force refresh of all windows
            foreach (Window window in app.Windows)
            {
                window.InvalidateVisual();
            }
        }
        #endregion
    }
    
}
