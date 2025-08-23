using ThemeGenerator.Components;
using ThemeGenerator.Model;

namespace ThemeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = new ThemeGeneratorScript();
            parser.CreateGenericTheme(ThemeParserConfig.GetGitHubConfig());
        }
    }
}
