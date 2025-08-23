using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using static ThemeGenerator.Components.StyleInfo;

namespace ThemeGenerator.Components
{
    /// <summary>
    /// A class that contains methods to extract specific XML attribute values.
    /// </summary>
    public class ResourceDictionaryParser
    {
        #region Fields
        // The XML Namespace URI for the 'x:' prefix, which is a standard part of XAML.
        private const string XamlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";
        #endregion

        #region Methods
        /// <summary>
        /// Extracts and returns a collection of StyleInfo objects from a .xaml file.
        /// </summary>
        /// <param name="filePath">The absolute path to ResourceDictionary.</param>
        /// <returns>A list of StyleInfo objects, each representing a parsed style.</returns>
        public List<StyleInfo> ExtractAllStylesFromFile(string filePath)
        {
            var xamlCode = File.ReadAllText(filePath);
            return ExtractAllStylesFromXaml(xamlCode);
        }

        /// <summary>
        /// Extracts and returns a collection of StyleInfo objects from a multi-style XML string.
        /// </summary>
        /// <param name="stylesXml">The XML content containing ResourceDictionary declarations.</param>
        /// <returns>A list of StyleInfo objects, each representing a parsed style.</returns>
        public List<StyleInfo> ExtractAllStylesFromXaml(string stylesXml)
        {
            List<StyleInfo> extractedStyles = new List<StyleInfo>();
            try
            {
                // To parse a fragment of XML, we must wrap it in a root element.
                XElement rootElement = XElement.Parse(stylesXml);

                var styleElements = rootElement.Elements().ToArray();
                // Find all "Style" elements within the root.
                //var styleElements = rootElement.Descendants("Style");

                // Loop through each found style element.
                foreach (var styleElement in styleElements)
                {
                    // Create a new StyleInfo object to store the data for this style.
                    StyleInfo styleInfo = new StyleInfo();

                    // Get the full XML string of the style element.
                    styleInfo.WholeStyleCode = styleElement.ToString();

                    // Extract the attributes, handling cases where they might not exist.
                    // For x:Key, we need to handle the namespace.
                    styleInfo.XKey = styleElement.Attribute(XName.Get("Key", XamlNamespace))?.Value ?? string.Empty;

                    // For TargetType and BasedOn, they don't have a namespace prefix.
                    styleInfo.TargetType = styleElement.Attribute("TargetType")?.Value ?? string.Empty;
                    styleInfo.BasedOn = styleElement.Attribute("BasedOn")?.Value ?? string.Empty;

                    // Extract all child setter elements.
                    var setterElements = styleElement.Elements().ToArray();
                    foreach (var setterElement in setterElements)
                    {
                        string property = setterElement.Attribute("Property")?.Value ?? string.Empty;
                        string value = setterElement.Attribute("Value")?.Value ?? string.Empty;

                        // Check if the value attribute contains a dynamic resource.
                        if (value.Contains("DynamicResource"))
                        {
                            // Use a regex to extract the resource name.
                            string pattern = @"{DynamicResource\s+([^}]+)}";
                            var match = Regex.Match(value, pattern);
                            string brushName = match.Success ? match.Groups[1].Value : string.Empty;

                            // Create a DynamicSetterInfo object.
                            styleInfo.Setters.Add(new DynamicSetterInfo
                            {
                                Property = property,
                                Value = value,
                                Brush = brushName
                            });
                        }
                        else
                        {
                            // Create a regular SetterInfo object.
                            styleInfo.Setters.Add(new SetterInfo
                            {
                                Property = property,
                                Value = value
                            });
                        }
                    }

                    // Add the populated object to our list.
                    extractedStyles.Add(styleInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing multi-style XML: {ex.Message}");
            }

            return extractedStyles;
        }

        /// <summary>
        ///  Extracts and returns a collection of StyleInfo objects from a .xaml file.
        /// </summary>
        /// <param name="filePath">The absolute path to ResourceDictionary.</param>
        /// <returns>A list of ColorInfo objects, each representing a parsed color.</returns>
        public List<ColorInfo> ExtractAllColorsFromFile(string filePath)
        {
            var xamlCode = File.ReadAllText(filePath);
            return ExtractAllColorsFromXaml(xamlCode);
        }

        /// <summary>
        ///  Extracts and returns a collection of StyleInfo objects from a .xaml file.
        /// </summary>
        /// <param name="xamlCode">The XML content containing ResourceDictionary declarations.</param>
        /// <returns>A list of ColorInfo objects, each representing a parsed color.</returns>
        public List<ColorInfo> ExtractAllColorsFromXaml(string xamlCode)
        {
            // To parse a fragment of XML, we must wrap it in a root element.
            XElement rootElement = XElement.Parse(xamlCode);

            var colorElements = rootElement.Elements().ToArray();
            // Find all "Style" elements within the root.
            //var styleElements = rootElement.Descendants("Style");

            var colors = new List<ColorInfo>();
            try
            {
                foreach (var color in colorElements)
                {
                    ColorInfo colorInfo = new ColorInfo();

                    colorInfo.XKey = color.Attribute(XName.Get("Key", XamlNamespace))?.Value ?? string.Empty;
                    colorInfo.ColorValue = color.Value ?? string.Empty;

                    colors.Add(colorInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing Color XML: {ex.Message}");
            }

            return colors;
        }

        public MergedResourceInfo ExtractMergedResourcesFromFile(string filePath)
        {
            var xmlCode = File.ReadAllText(filePath);
            return ExtractMergedResourcesFromXaml(xmlCode);
        }

        /// <summary>
        /// Extracts a MergedResourceInfo object from a <ResourceDictionary.MergedDictionaries> XML block.
        /// </summary>
        /// <param name="mergedDictionariesXml">The XML content of the merged dictionaries.</param>
        /// <returns>A MergedResourceInfo object with all child ResourceDictionary elements.</returns>
        public MergedResourceInfo ExtractMergedResourcesFromXaml(string mergedDictionariesXml)
        {
            MergedResourceInfo mergedInfo = new MergedResourceInfo();
            try
            {
                // Parse the XML string into an XElement object.
                XElement element = XElement.Parse(mergedDictionariesXml);

                var rootElements = element.Elements().ToArray();

                var mergedDictionariesRoot = rootElements.First(x => x.Name.LocalName == "ResourceDictionary.MergedDictionaries");

                // Find all child <ResourceDictionary> elements.
                var dictionaryElements = mergedDictionariesRoot.Elements().ToArray();

                foreach (var dictElement in dictionaryElements)
                {
                    // Create a new ResourceDictionaryInfo object.
                    ResourceDictionaryInfo dictInfo = new ResourceDictionaryInfo();
                    dictInfo.Source = dictElement.Attribute("Source")?.Value ?? string.Empty;
                    mergedInfo.ResourceDictionaries.Add(dictInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing merged dictionaries XML: {ex.Message}");
            }
            return mergedInfo;
        }

        public string ExtractResourceDictionaryWithAttributesFromFile(string filePath)
        {
            var xmlCode = File.ReadAllText(filePath);
            return ExtractResourceDictionaryWithAttributes(xmlCode);
        }

        /// <summary>
        /// Extracts a ResourceDictionary element, keeping its attributes but removing all child elements.
        /// </summary>
        /// <param name="resourceDictionaryXml">The XML content of the ResourceDictionary.</param>
        /// <returns>The XML string of the ResourceDictionary with only its attributes.</returns>
        public string ExtractResourceDictionaryWithAttributes(string resourceDictionaryXml)
        {
            try
            {
                // Parse the original XML string.
                XElement originalElement = XElement.Parse(resourceDictionaryXml);

                // Create a new XElement with the same name and attributes, but no content.
                XElement newElement = new XElement(originalElement.Name, originalElement.Attributes());

                // Return the new element's string representation.
                return newElement.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing ResourceDictionary XML: {ex.Message}");
                return string.Empty;
            }
        }

        public string CreateGenericResource(string rootXmlCode, MergedResourceInfo mergedResource, IEnumerable<StyleInfo> styles)
        {
            XNamespace presentationNs = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            XNamespace xamlNs = "http://schemas.microsoft.com/winfx/2006/xaml";
            XNamespace virelaNs = "http://schemas.virela.com/winfx/xaml/controls";

            XElement rootElement = new XElement(presentationNs + "ResourceDictionary",
                new XAttribute("xmlns", presentationNs.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "x", xamlNs),
                new XAttribute(XNamespace.Xmlns + "virela", virelaNs));

            //XElement rootElement = XElement.Parse(rootXmlCode);
            rootElement.Add(mergedResource.ToXElement(rootElement.Name.NamespaceName));

            foreach (StyleInfo styleInfo in styles)
                rootElement.Add(styleInfo.ToXElement(presentationNs, xamlNs));

            // Use a StringWriter and XmlWriterSettings to guarantee formatted output.
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            var stringBuilder = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(stringBuilder, settings);
            rootElement.Save(xmlWriter);

            return rootElement.ToString();
        }
        #endregion
    }
}
