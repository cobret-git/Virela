using Virela.GitHub.Components.Enums;

namespace Virela.GitHub.Components.EventArgs
{
    public class PaletteChangedEventArgs : System.EventArgs
    {
        public PaletteChangedEventArgs(GitHubPalette oldTheme, GitHubPalette newTheme)
        {
            OldTheme = oldTheme;
            NewTheme = newTheme;
        }
        public GitHubPalette OldTheme { get; }
        public GitHubPalette NewTheme { get; }
    }
}
