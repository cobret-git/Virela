using System.Xml.Linq;
using ThemeGenerator.Components;

namespace ThemeGenerator.Model;

public class ThemeGeneratorScript
{
    #region Fields
    private readonly string solutionDir;
    #endregion

    #region Constructors
    public ThemeGeneratorScript()
    {
        solutionDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\.."));
    }
    #endregion

    #region Methods
    public void CreateGenericTheme(ThemeParserConfig config)
    {
        var projectDirPath = Path.Combine(solutionDir, config.ProjectName);
        var genericFilePath = Path.Combine(projectDirPath, config.ThemesDirectory, "Generic.xaml");
        var defaultPaletteFilePath = Path.Combine(projectDirPath, config.PalettesDirectory, config.DefaultPaletteName);
        var stylesFilePath = Path.Combine(projectDirPath, config.StylesDirectory, "Styles.xaml");
        var defaultThemeFilePath = Path.Combine(projectDirPath, config.ThemesDirectory, config.DefaultThemeName);

        var xamlParser = new ResourceDictionaryParser();

        var styles = xamlParser.ExtractAllStylesFromFile(stylesFilePath);
        var colors = xamlParser.ExtractAllColorsFromFile(defaultPaletteFilePath);

        //change to strictly defined colors
        foreach (var style in styles)
        {
            if (string.IsNullOrWhiteSpace(style.XKey)) continue; //default style
            foreach(var setter in style.Setters)
            {
                if (setter is not DynamicSetterInfo dySetter) continue; //nothing to change here
                var colorName = string.Concat(dySetter.Brush.Split("Brush"));
                var color = colors.FirstOrDefault(x => x.XKey == colorName);
                if (color == null) Console.WriteLine("Color was not found");
                else setter.Value = color.ColorValue;
            }
        }
        var mergedResources = xamlParser.ExtractMergedResourcesFromFile(defaultThemeFilePath);

        //remove the non-generic resources.
        var resourcesToExclude = new List<ResourceDictionaryInfo>();
        foreach(var resource in mergedResources.ResourceDictionaries)
        {
            if (resource.Source.Contains("\\Styles.xaml") || resource.Source.Contains("/Styles.xaml")) resourcesToExclude.Add(resource);
        }
        foreach (var resource in resourcesToExclude) mergedResources.ResourceDictionaries.Remove(resource);

        var rootDeclaration = xamlParser.ExtractResourceDictionaryWithAttributesFromFile(defaultThemeFilePath);

        var text = xamlParser.CreateGenericResource(rootDeclaration, mergedResources, styles);

        File.WriteAllText(genericFilePath, text);
    }
    #endregion
}