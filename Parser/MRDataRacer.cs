using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parser
{
	[XmlRoot(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
	public class Driver
	{
		[XmlElement(ElementName = "GivenName", Namespace = "http://ergast.com/mrd/1.5")]
		public string GivenName { get; set; }
		[XmlElement(ElementName = "FamilyName", Namespace = "http://ergast.com/mrd/1.5")]
		public string FamilyName { get; set; }
		[XmlElement(ElementName = "DateOfBirth", Namespace = "http://ergast.com/mrd/1.5")]
		public string DateOfBirth { get; set; }
		[XmlElement(ElementName = "Nationality", Namespace = "http://ergast.com/mrd/1.5")]
		public string Nationality { get; set; }
		[XmlAttribute(AttributeName = "driverId")]
		public string DriverId { get; set; }
		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }
		[XmlElement(ElementName = "PermanentNumber", Namespace = "http://ergast.com/mrd/1.5")]
		public string PermanentNumber { get; set; }
		[XmlAttribute(AttributeName = "code")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "DriverTable", Namespace = "http://ergast.com/mrd/1.5")]
	public class DriverTable
	{
		[XmlElement(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
		public List<Driver> Driver { get; set; }
	}

	[XmlRoot(ElementName = "MRData", Namespace = "http://ergast.com/mrd/1.5")]
	public class MRDataRacer
	{
		[XmlElement(ElementName = "DriverTable", Namespace = "http://ergast.com/mrd/1.5")]
		public DriverTable DriverTable { get; set; }
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
