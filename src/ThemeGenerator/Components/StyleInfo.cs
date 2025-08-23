using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ThemeGenerator.Components
{
    /// <summary>
    /// A class to hold the extracted information for a single <Style/> declaration.
    /// </summary>
    public class StyleInfo
    {
        // The XML Namespace URI for the 'x:' prefix, which is a standard part of XAML.
        private const string XamlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";

        public string WholeStyleCode { get; set; } = string.Empty;
        public string XKey { get; set; } = string.Empty;
        public string TargetType { get; set; } = string.Empty;
        public string BasedOn { get; set; } = string.Empty;
        public List<SetterInfo> Setters { get; set; } = new List<SetterInfo>();

        /// <summary>
        /// Reconstructs the full XML string for the style element, including all attributes and setters.
        /// </summary>
        /// <returns>The reconstructed XML string.</returns>
        public string ToXmlString()
        {
            var styleElement = new XElement("Style");

            if (!string.IsNullOrEmpty(XKey))
            {
                // Create an XName for the x:Key attribute with its namespace.
                styleElement.Add(new XAttribute(XName.Get("Key", XamlNamespace), XKey));
            }

            if (!string.IsNullOrEmpty(TargetType))
            {
                styleElement.Add(new XAttribute("TargetType", TargetType));
            }

            if (!string.IsNullOrEmpty(BasedOn))
            {
                styleElement.Add(new XAttribute("BasedOn", BasedOn));
            }

            foreach (var setter in Setters)
            {
                // Use the setter's ToXmlString method to get its XML representation
                // and add it to the style element. We parse it to an XElement first.
                // This ensures proper XML structure and formatting.
                styleElement.Add(XElement.Parse(setter.ToXmlString()));
            }

            // Return the formatted XML string.
            return styleElement.ToString();
        }
        public XElement ToXElement(XNamespace presentatnionNs, XNamespace xamlNs)
        {
            XElement rootELement = new XElement(presentatnionNs + "Style");
            if (!string.IsNullOrWhiteSpace(XKey)) 
                rootELement.Add(new XAttribute(xamlNs + "Key", XKey));
            if (!string.IsNullOrWhiteSpace(TargetType))
                rootELement.Add(new XAttribute("TargetType", TargetType));
            if (!string.IsNullOrWhiteSpace(BasedOn))
                rootELement.Add(new XAttribute("BasedOn", BasedOn));
            foreach (var setter in Setters)
                rootELement.Add(setter.ToXElement(presentatnionNs));

            return rootELement;
        }
    }

    /// <summary>
    /// A class to hold the extracted information for a single <Setter/> element.
    /// </summary>
    public class SetterInfo
    {
        public string Property { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Updates the Value property and returns a new XML string for the setter.
        /// </summary>
        /// <param name="newValue">The new value for the 'Value' attribute.</param>
        /// <returns>The new XML string for the setter.</returns>
        public string ToXmlString()
        {
            return $"<Setter Property=\"{Property}\" Value=\"{Value}\" />";
        }
        public XElement ToXElement(XNamespace presentatnionNs)
        {
            XElement rootElement = new XElement(presentatnionNs + "Setter");
            rootElement.Add(new XAttribute("Property", Property));
            rootElement.Add(new XAttribute("Value", Value));
            return rootElement;
        }
    }

    /// <summary>
    /// A class that represents a <Setter/> with a dynamic resource value.
    /// It inherits from SetterInfo and adds a property for the brush name.
    /// </summary>
    public class DynamicSetterInfo : SetterInfo
    {
        public string Brush { get; set; } = string.Empty;
    }

    /// <summary>
    /// A class to hold the extracted information for a single <Color/> element.
    /// </summary>
    public class ColorInfo
    {
        public string XKey { get; set; } = string.Empty;
        public string ColorValue { get; set; } = string.Empty;
    }

    /// <summary>
    /// A class to hold the extracted information for a <ResourceDictionary.MergedDictionaries> block.
    /// </summary>
    public class MergedResourceInfo
    {
        public List<ResourceDictionaryInfo> ResourceDictionaries { get; set; } = new List<ResourceDictionaryInfo>();

        public string ToXmlString()
        {
            var mergerResourceElement = new XElement("ResourceDictionary.MergedDictionaries");
            

            foreach (var resource in ResourceDictionaries)
                mergerResourceElement.Add(XElement.Parse(resource.ToXmlString()));

            // Use a StringWriter and XmlWriterSettings to guarantee formatted output.
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                mergerResourceElement.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public XElement ToXElement(string namespaceName)
        {
            var rootXName = XName.Get("ResourceDictionary.MergedDictionaries", namespaceName);
            var rootXElement = new XElement(rootXName);
            foreach (var mr in ResourceDictionaries)
                rootXElement.Add(mr.ToXElement(namespaceName));
            return rootXElement;
        }
    }

    /// <summary>
    /// A class to hold the extracted information for a single <ResourceDictionary> element.
    /// </summary>
    public class ResourceDictionaryInfo
    {
        public string Source { get; set; } = string.Empty;

        public string ToXmlString()
        {
            return $"<ResourceDictionary Source=\"{Source}\" />";
        }
        public XElement ToXElement(string namespaceName)
        {
            var rootXName = XName.Get("ResourceDictionary", namespaceName);
            var rootXElement = new XElement(rootXName);
            var sourceAttr = new XAttribute("Source", Source);
            rootXElement.Add(sourceAttr);
            return rootXElement;
        }
    }
}
