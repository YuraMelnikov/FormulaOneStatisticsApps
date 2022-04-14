using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parser
{
	[XmlRoot(ElementName = "Location", Namespace = "http://ergast.com/mrd/1.5")]
	public class LocationQua
	{
		[XmlElement(ElementName = "Locality", Namespace = "http://ergast.com/mrd/1.5")]
		public string Locality { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "http://ergast.com/mrd/1.5")]
		public string Country { get; set; }
		[XmlAttribute(AttributeName = "lat")]
		public string Lat { get; set; }
		[XmlAttribute(AttributeName = "long")]
		public string Long { get; set; }
	}

	[XmlRoot(ElementName = "Circuit", Namespace = "http://ergast.com/mrd/1.5")]
	public class CircuitQua
	{
		[XmlElement(ElementName = "CircuitName", Namespace = "http://ergast.com/mrd/1.5")]
		public string CircuitName { get; set; }
		[XmlElement(ElementName = "Location", Namespace = "http://ergast.com/mrd/1.5")]
		public LocationQua Location { get; set; }
		[XmlAttribute(AttributeName = "circuitId")]
		public string CircuitId { get; set; }
		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
	public class DriverQua
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
		[XmlAttribute(AttributeName = "code")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
	public class ConstructorQua
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

	[XmlRoot(ElementName = "QualifyingResult", Namespace = "http://ergast.com/mrd/1.5")]
	public class QualifyingResult
	{
		[XmlElement(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
		public DriverQua Driver { get; set; }
		[XmlElement(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
		public ConstructorQua Constructor { get; set; }
		[XmlElement(ElementName = "Q1", Namespace = "http://ergast.com/mrd/1.5")]
		public string Q1 { get; set; }
		[XmlElement(ElementName = "Q2", Namespace = "http://ergast.com/mrd/1.5")]
		public string Q2 { get; set; }
		[XmlElement(ElementName = "Q3", Namespace = "http://ergast.com/mrd/1.5")]
		public string Q3 { get; set; }
		[XmlAttribute(AttributeName = "number")]
		public string Number { get; set; }
		[XmlAttribute(AttributeName = "position")]
		public string Position { get; set; }
	}

	[XmlRoot(ElementName = "QualifyingList", Namespace = "http://ergast.com/mrd/1.5")]
	public class QualifyingList
	{
		[XmlElement(ElementName = "QualifyingResult", Namespace = "http://ergast.com/mrd/1.5")]
		public List<QualifyingResult> QualifyingResult { get; set; }
	}

	[XmlRoot(ElementName = "Race", Namespace = "http://ergast.com/mrd/1.5")]
	public class Race
	{
		[XmlElement(ElementName = "RaceName", Namespace = "http://ergast.com/mrd/1.5")]
		public string RaceName { get; set; }
		[XmlElement(ElementName = "Circuit", Namespace = "http://ergast.com/mrd/1.5")]
		public CircuitQua Circuit { get; set; }
		[XmlElement(ElementName = "Date", Namespace = "http://ergast.com/mrd/1.5")]
		public string Date { get; set; }
		[XmlElement(ElementName = "QualifyingList", Namespace = "http://ergast.com/mrd/1.5")]
		public QualifyingList QualifyingList { get; set; }
		[XmlAttribute(AttributeName = "season")]
		public string Season { get; set; }
		[XmlAttribute(AttributeName = "round")]
		public string Round { get; set; }
		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "RaceTable", Namespace = "http://ergast.com/mrd/1.5")]
	public class RaceTable
	{
		[XmlElement(ElementName = "Race", Namespace = "http://ergast.com/mrd/1.5")]
		public Race Race { get; set; }
		[XmlAttribute(AttributeName = "season")]
		public string Season { get; set; }
		[XmlAttribute(AttributeName = "round")]
		public string Round { get; set; }
	}

	[XmlRoot(ElementName = "MRData", Namespace = "http://ergast.com/mrd/1.5")]
	public class MRDataQual
	{
		[XmlElement(ElementName = "RaceTable", Namespace = "http://ergast.com/mrd/1.5")]
		public RaceTable RaceTable { get; set; }
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
