using System.Xml.Serialization;

namespace Parser
{
    public class ChampXML
    {
		[XmlRoot(ElementName = "Location", Namespace = "http://ergast.com/mrd/1.5")]
		public class Location
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
		public class Circuit
		{
			[XmlElement(ElementName = "CircuitName", Namespace = "http://ergast.com/mrd/1.5")]
			public string CircuitName { get; set; }
			[XmlElement(ElementName = "Location", Namespace = "http://ergast.com/mrd/1.5")]
			public Location Location { get; set; }
			[XmlAttribute(AttributeName = "circuitId")]
			public string CircuitId { get; set; }
			[XmlAttribute(AttributeName = "url")]
			public string Url { get; set; }
		}

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

		[XmlRoot(ElementName = "Status", Namespace = "http://ergast.com/mrd/1.5")]
		public class Status
		{
			[XmlAttribute(AttributeName = "statusId")]
			public string StatusId { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "Time", Namespace = "http://ergast.com/mrd/1.5")]
		public class Time
		{
			[XmlAttribute(AttributeName = "millis")]
			public string Millis { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "Result", Namespace = "http://ergast.com/mrd/1.5")]
		public class Result
		{
			[XmlElement(ElementName = "Driver", Namespace = "http://ergast.com/mrd/1.5")]
			public Driver Driver { get; set; }
			[XmlElement(ElementName = "Constructor", Namespace = "http://ergast.com/mrd/1.5")]
			public Constructor Constructor { get; set; }
			[XmlElement(ElementName = "Grid", Namespace = "http://ergast.com/mrd/1.5")]
			public string Grid { get; set; }
			[XmlElement(ElementName = "Laps", Namespace = "http://ergast.com/mrd/1.5")]
			public string Laps { get; set; }
			[XmlElement(ElementName = "Status", Namespace = "http://ergast.com/mrd/1.5")]
			public Status Status { get; set; }
			[XmlElement(ElementName = "Time", Namespace = "http://ergast.com/mrd/1.5")]
			public Time Time { get; set; }
			[XmlAttribute(AttributeName = "number")]
			public string Number { get; set; }
			[XmlAttribute(AttributeName = "position")]
			public string Position { get; set; }
			[XmlAttribute(AttributeName = "positionText")]
			public string PositionText { get; set; }
			[XmlAttribute(AttributeName = "points")]
			public string Points { get; set; }
		}

		[XmlRoot(ElementName = "ResultsList", Namespace = "http://ergast.com/mrd/1.5")]
		public class ResultsList
		{
			[XmlElement(ElementName = "Result", Namespace = "http://ergast.com/mrd/1.5")]
			public List<Result> Result { get; set; }
		}

		[XmlRoot(ElementName = "Race", Namespace = "http://ergast.com/mrd/1.5")]
		public class Race
		{
			[XmlElement(ElementName = "RaceName", Namespace = "http://ergast.com/mrd/1.5")]
			public string RaceName { get; set; }
			[XmlElement(ElementName = "Circuit", Namespace = "http://ergast.com/mrd/1.5")]
			public Circuit Circuit { get; set; }
			[XmlElement(ElementName = "Date", Namespace = "http://ergast.com/mrd/1.5")]
			public string Date { get; set; }
			[XmlElement(ElementName = "ResultsList", Namespace = "http://ergast.com/mrd/1.5")]
			public ResultsList ResultsList { get; set; }
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
		public class MRData
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
}
