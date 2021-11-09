using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities.Concrete.Xmls
{
    [XmlRoot(ElementName = "transfer")]
	public class Transfer
	{
		[XmlElement(ElementName = "sourceGLN")]
		public string SourceGLN { get; set; }

		[XmlElement(ElementName = "destinationGLN")]
		public string DestinationGLN { get; set; }

		[XmlElement(ElementName = "actionType")]
		public string ActionType { get; set; }

		[XmlElement(ElementName = "shipTo")]
		public string ShipTo { get; set; }

		[XmlElement(ElementName = "documentNumber")]
		public string DocumentNumber { get; set; }

		[XmlElement(ElementName = "documentDate")]
		public DateTime DocumentDate { get; set; }

		[XmlElement(ElementName = "note")]
		public string Note { get; set; }

		[XmlElement(ElementName = "vesion")]
		public string Vesion { get; set; }

		[XmlElement(ElementName = "carrier")]
		public List<Carrier> Carrier { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation")]
		public string NoNamespaceSchemaLocation { get; set; }
	}
}
