using System.Xml.Serialization;

namespace URLRequest
{
    [XmlRoot("Root")]
    public class SampleXMLData
    {
        [XmlElement("data")]
        public XMLData xmlData;
    }

    public class XMLData
    {
        [XmlElement("id")]
        public string id;

        [XmlElement("text")]
        public string text;
    }
}
