using Core.Utilities.IO;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core.Extensions
{
    public static class XmlExtensions
    {
        public static string ToXml(this object value, Encoding encoding = null)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;
            if (encoding == null)
                encoding = new UTF8Encoding(false);
            using (StringWriter stringWriter = new StringWriterWithEncoding(encoding, new StringBuilder()))
            using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter)
            {
                Formatting = Formatting.Indented
            })
            {
                XmlSerializer xmlSerializer = new XmlSerializer(value.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                
                ns.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(xmlWriter, value, ns);
                return stringWriter.ToString();
            }
        }


        public static T FromXml<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return default;
            try
            {
                using (StringReader stringReader = new StringReader(value))
                    return (T)new XmlSerializer(typeof(T)).Deserialize(stringReader);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
