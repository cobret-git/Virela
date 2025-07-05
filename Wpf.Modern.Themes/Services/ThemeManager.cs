using System.Windows;

namespace Wpf.Modern.Themes.Services
{
    public class ThemeManager
    {
        #region Fields
        private readonly Dictionary<WpfTheme, string> AvailableThemes = new()
        {
            { WpfTheme.GithubDark, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkTheme.xaml" },
            { WpfTheme.GithubDarkHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkHighContrastTheme.xaml" },
            { WpfTheme.GithubDarkColorblind, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkColorblindTheme.xaml" },
            { WpfTheme.GithubDarkColorblindHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkColorblindHighContrastTheme.xaml" },
            { WpfTheme.GithubDarkTritanopia, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkTritanopiaTheme.xaml" },
            { WpfTheme.GithubDarkTritanopiaHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubDarkTritanopiaHighContrastTheme.xaml" }, 

            { WpfTheme.GithubLight, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightTheme.xaml" },
            { WpfTheme.GithubLightHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightHighContrastTheme.xaml" },
            { WpfTheme.GithubLightColorblind, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightColorblindTheme.xaml" },
            { WpfTheme.GithubLightColorblindHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightColorblindHighContrastTheme.xaml" },
            { WpfTheme.GithubLightTritanopia, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightTritanopiaTheme.xaml" },
            { WpfTheme.GithubLightTritanopiaHighContrast, "pack://application:,,,/Wpf.Modern.Themes;component/Themes/Github/Themes/GithubLightTritanopiaHighContrastTheme.xaml" },
        };
        #endregion

        #region Consts

        private const string ThemeResourceKey = "CurrentThemeLibrary";
        #endregion

        #region Events
        public event EventHandler<ThemeChangedEventArgs>? ThemeChanged;
        #endregion

        #region Properties
        public WpfTheme CurrentTheme { get; private set; }
        #endregion

        #region Methods
        public void ApplyTheme(WpfTheme theme)
        {
            if (!AvailableThemes.ContainsKey(theme))
                throw new ArgumentException($"Theme '{theme}' is not available.");

            var app = Application.Current;
            var oldTheme = CurrentTheme;

            // Remove existing theme
            var existingTheme = app.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Contains(ThemeResourceKey));

            if (existingTheme != null)
            {
                app.Resources.MergedDictionaries.Remove(existingTheme);
            }

            // Add new theme
            var themeUri = new Uri(AvailableThemes[theme], UriKind.Absolute);
            var newTheme = new ResourceDictionary { Source = themeUri };
            newTheme[ThemeResourceKey] = theme;

            app.Resources.MergedDictionaries.Add(newTheme);

            CurrentTheme = theme;

            // Notify about theme change
            ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(oldTheme, theme));

            // Force refresh of all windows
            foreach (Window window in app.Windows)
            {
                window.InvalidateVisual();
            }
        }
        #endregion
    }
}
