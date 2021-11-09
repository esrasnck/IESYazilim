using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities.Concrete.Xmls
{
    [XmlRoot(ElementName = "productList")]
	public class ProductList
	{
		[XmlElement(ElementName = "serialNumber")]
		public List<string> SerialNumber { get; set; }

		[XmlAttribute(AttributeName = "GTIN")]
		public string GTIN { get; set; }

		[XmlAttribute(AttributeName = "lotNumber")]
		public string LotNumber { get; set; }

		[XmlAttribute(AttributeName = "productionDate")]
		public DateTime ProductionDate { get; set; }

		[XmlAttribute(AttributeName = "expirationDate")]
		public DateTime ExpirationDate { get; set; }
	}
}
