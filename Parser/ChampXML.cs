using System.Xml.Serialization;

namespace Parser
{
    public class ChampXML
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
		}

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

		[XmlRoot(ElementName = "DriverStanding", Namespace = "http://ergast.com/mrd/1.5")]
		public class DriverStanding
		{
			[XmlElement(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
			public Driver Driver { get; set; }
			[XmlElement(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
			public List<Constructor> Constructor { get; set; }
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
		public class StandingsList
		{
			[XmlElement(ElementName = "DriverStanding", Namespace = "http://ergast.com/mrd/1.5")]
			public List<DriverStanding> DriverStanding { get; set; }
			[XmlAttribute(AttributeName = "season")]
			public string Season { get; set; }
			[XmlAttribute(AttributeName = "round")]
			public string Round { get; set; }
		}

		[XmlRoot(ElementName = "StandingsTable", Namespace = "http://ergast.com/mrd/1.5")]
		public class StandingsTable
		{
			[XmlElement(ElementName = "StandingsList", Namespace = "http://ergast.com/mrd/1.5")]
			public StandingsList StandingsList { get; set; }
			[XmlAttribute(AttributeName = "season")]
			public string Season { get; set; }
			[XmlAttribute(AttributeName = "round")]
			public string Round { get; set; }
		}

		[XmlRoot(ElementName = "MRData", Namespace = "http://ergast.com/mrd/1.5")]
		public class MRData
		{
			[XmlElement(ElementName = "StandingsTable", Namespace = "http://ergast.com/mrd/1.5")]
			public StandingsTable StandingsTable { get; set; }
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
}
