namespace ThemeGenerator.Components;

public class ThemeParserConfig
{
    #region Properties
    public string ProjectName { get; init; } = null!;
    public string PalettesDirectory { get; init; } = "Palettes";
    public string ThemesDirectory { get; init; } = "Themes";
    public string StylesDirectory { get; init; } = "Styles";
    public string DefaultPaletteName { get; init; } = "Default";
    public string DefaultThemeName { get; init; } = "Default";
    #endregion

    #region Static Methods
    public static ThemeParserConfig GetGitHubConfig()
    {
        return new ThemeParserConfig()
        {
            ProjectName = "Virela.GitHub",
            DefaultPaletteName = "LightPalette.xaml",
            DefaultThemeName = "LightTheme.xaml"
        };
    }
    #endregion
}