using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parser
{

	[XmlRoot(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
	public class Constructor2
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

	[XmlRoot(ElementName = "ConstructorStanding", Namespace = "http://ergast.com/mrd/1.5")]
	public class ConstructorStanding1
	{
		[XmlElement(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
		public Constructor2 Constructor { get; set; }
		[XmlAttribute(AttributeName = "position")]
		public string Position { get; set; }
		[XmlAttribute(AttributeName = "positionText")]
		public string PositionText { get; set; }
		[XmlAttribute(AttributeName = "points")]
		public string Points { get; set; }
		[XmlAttribute(AttributeName = "wins")]
		public string Wins { get; set; }
	}

	[XmlRoot(ElementName = "StandingsList", Namespace = "http://ergast.com/mrd/1.5")]
	public class StandingsList1
	{
		[XmlElement(ElementName = "ConstructorStanding", Namespace = "http://ergast.com/mrd/1.5")]
		public List<ConstructorStanding1> ConstructorStanding { get; set; }
		[XmlAttribute(AttributeName = "season")]
		public string Season { get; set; }
		[XmlAttribute(AttributeName = "round")]
		public string Round { get; set; }
	}

	[XmlRoot(ElementName = "StandingsTable", Namespace = "http://ergast.com/mrd/1.5")]
	public class StandingsTable1
	{
		[XmlElement(ElementName = "StandingsList", Namespace = "http://ergast.com/mrd/1.5")]
		public StandingsList1 StandingsList { get; set; }
		[XmlAttribute(AttributeName = "season")]
		public string Season { get; set; }
		[XmlAttribute(AttributeName = "round")]
		public string Round { get; set; }
	}

	[XmlRoot(ElementName = "MRData", Namespace = "http://ergast.com/mrd/1.5")]
	public class MRDataChampTeam
	{
		[XmlElement(ElementName = "StandingsTable", Namespace = "http://ergast.com/mrd/1.5")]
		public StandingsTable1 StandingsTable { get; set; }
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
