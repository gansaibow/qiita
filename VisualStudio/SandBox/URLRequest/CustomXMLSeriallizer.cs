using System.IO;
using System.Xml.Serialization;

namespace URLRequest
{
    public static class CustomXMLSeriallizer
    {
        public static T LoadXmlDataString<T>(string xmltext) where T : class
        {
            XmlSerializer serializer =new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xmltext);
            T loadAry = (T)serializer.Deserialize(reader);
            reader.Close();
            return loadAry;
        }
    }
}
