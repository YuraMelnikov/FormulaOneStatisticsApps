using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parser
{
	[XmlRoot(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
	public class Constructor
	{
		[XmlElement(ElementName = "Name", Namespace = "http://ergast.com/mrd/1.5")]
		public string Name { get; set; }
		[XmlElement(ElementName = "Nationality", Namespace = "http://ergast.com/mrd/1.5")]
		public string Nationality { get; set; }
		[XmlAttribute(AttributeName = "constructorId")]
		public string ConstructorId { get; set; }
		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "ConstructorTable", Namespace = "http://ergast.com/mrd/1.5")]
	public class ConstructorTable
	{
		[XmlElement(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
		public List<Constructor> Constructor { get; set; }
	}

	[XmlRoot(ElementName = "MRData", Namespace = "http://ergast.com/mrd/1.5")]
	public class MRDataConstructor
	{
		[XmlElement(ElementName = "ConstructorTable", Namespace = "http://ergast.com/mrd/1.5")]
		public ConstructorTable ConstructorTable { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "series")]
		public string Series { get; set; }
		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }
		[XmlAttribute(AttributeName = "limit")]
		public string Limit { get; set; }
		[XmlAttribute(AttributeName = "offset")]
		public string Offset { get; set; }
		[XmlAttribute(AttributeName = "total")]
		public string Total { get; set; }
	}
}
