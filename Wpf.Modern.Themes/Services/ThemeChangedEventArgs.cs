namespace Wpf.Modern.Themes.Services
{
    public class ThemeChangedEventArgs : EventArgs
    {
        public WpfTheme OldTheme { get; }
        public WpfTheme NewTheme { get; }

        public ThemeChangedEventArgs(WpfTheme oldTheme, WpfTheme newTheme)
        {
            OldTheme = oldTheme;
            NewTheme = newTheme;
        }
    }
}
