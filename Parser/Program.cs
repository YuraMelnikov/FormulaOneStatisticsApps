//https://ergast.com/api/f1/1950/7/driverStandings
//https://ergast.com/api/f1/1950/7/constructorStandings

using AngleSharp;
using AngleSharp.Dom;
using Entities.Models;
using Parser;
using System.Xml.Serialization;
using static Parser.ChampXML;

RepositoryParcer repository = new RepositoryParcer();
List<string> list = new List<string>();

for (var i = 1950; i <= 2019; i++)
{
    var idSeason = repository.Seasons.First(a => a.Year == i).Id;
    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == idSeason);


    string startPage = "https://ergast.com/api/f1/" + i.ToString() + "/" + countGp.ToString() + "/driverStandings";

    var config = Configuration.Default.WithDefaultLoader();
    var context = BrowsingContext.New(config);
    IDocument document = await context.OpenAsync(startPage);

    XmlSerializer serializer = new XmlSerializer(typeof(MRData));
    using (StringReader reader = new StringReader(document.Source.Text))
    {
        var test = (MRData)serializer.Deserialize(reader);

        var drivers = test.StandingsTable.StandingsList.DriverStanding.ToArray();

        int notNull = 0;
        int isNull = 0;


        foreach(var driver in drivers)
        {
            var familyName = driver.Driver.FamilyName;
            var givenName = driver.Driver.GivenName;

            var dr = repository.Racers.FirstOrDefault(a => a.FirstName == givenName && a.SecondName ==  familyName);


            //var addItem = new SeasonRacersClassification { 
            //    IdRacer = dr.Id, 
            //    IdSeason = idSeason,
            //    Points = (float)Convert.ToDecimal(driver.Points), 
            //    Position = Convert.ToInt32(driver.Position)
            //};
            if (dr != null)
                notNull++;
            else
            {
                list.Add(familyName + " " + givenName);
                isNull++;
            }
        }

    }

}
var t = 0;