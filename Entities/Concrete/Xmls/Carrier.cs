using System.Xml.Serialization;

namespace Entities.Concrete.Xmls
{

    [XmlRoot(ElementName = "carrier")]
	public class Carrier
	{
		[XmlElement(ElementName = "productList")]
		public ProductList ProductList { get; set; }

		[XmlAttribute(AttributeName = "carrierLabel")]
		public string CarrierLabel { get; set; }

		[XmlAttribute(AttributeName = "containerType")]
		public string ContainerType { get; set; }
	}
}
