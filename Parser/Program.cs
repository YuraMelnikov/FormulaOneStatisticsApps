//https://ergast.com/api/f1/1950/7/driverStandings
//https://ergast.com/api/f1/1950/7/constructorStandings

using AngleSharp;
using AngleSharp.Dom;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Parser;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static Parser.ChampXML;

RepositoryParcer repository = new RepositoryParcer();

//var listP = repository.Participants.ToArray();
//foreach(var pt in listP)
//{
//    var n = pt.Number.Replace("<b>", "").Replace("</b>", "");
//    if(n != pt.Number)
//    {
//        pt.Number = n;
//        repository.Update(pt);
//        repository.SaveChanges();
//    }
//}


int count = 0;


for (var i = 1950; i <= 2022; i++)
{
    Console.WriteLine(i.ToString());
    var idSeason = repository.Seasons.First(a => a.Year == i).Id;
    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == idSeason);

    for (var j = 1; j <= countGp; j++)
    {
        var grandPrix = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == idSeason && a.NumberInSeason == j);

        string startPage = "http://ergast.com/api/f1/" + i.ToString() + "/" + j.ToString() + "/results";

        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        IDocument document = await context.OpenAsync(startPage);

        XmlSerializer serializer = new XmlSerializer(typeof(MRData));
        using (StringReader reader = new StringReader(document.Source.Text))
        {
            var test = (MRData)serializer.Deserialize(reader);
            var results = test.RaceTable.Race.ResultsList.Result;
            if (test.RaceTable.Race.RaceName != grandPrix.FullName)
            {
                Console.WriteLine("Name: {0} - {1}", test.RaceTable.Race.RaceName, grandPrix.Name);
                grandPrix.Name = test.RaceTable.Race.RaceName;
                repository.Update(grandPrix);
                repository.SaveChanges();
            }
            foreach (var res in results)
            {
                var parsipient = repository.Participants
                    .Include(a => a.Racer)
                    .Include(a => a.Tyre)
                    .Include(a => a.Chassis)
                    .Include(a => a.Engine)
                    .FirstOrDefault(a => a.IdGrandPrix == grandPrix.Id
                    && a.Racer.TimeApiId == res.Driver.DriverId
                    && a.Number == res.Number
                    );
                GrandPrixResult gpResult;


                gpResult = repository.GrandPrixResults.FirstOrDefault(s => s.IdParticipant == parsipient.Id);


                if (parsipient is null | gpResult is null)
                {
                    Console.WriteLine(count.ToString());

                    count++;

                    parsipient = repository.Participants
                        .Include(a => a.Racer)
                        .Include(a => a.Tyre)
                        .Include(a => a.Chassis)
                        .Include(a => a.Engine)
                        .FirstOrDefault(a => a.IdGrandPrix == grandPrix.Id && a.Racer.TimeApiId == res.Driver.DriverId);
                    gpResult = repository.GrandPrixResults
                        .FirstOrDefault(s => s.IdParticipant == parsipient.Id);
                }

                var constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
                if (constTime is null)
                {
                    var newTimeName = new TeamName
                    {
                        Name = res.Constructor.Name,
                        TimeApiId = res.Constructor.ConstructorId,
                        IdCountry = repository.Countries.FirstOrDefault(a => a.Name == res.Constructor.Nationality).Id
                    };
                    repository.Add(newTimeName);
                    repository.SaveChanges();
                    constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
                }
                if (parsipient.IdTeamName != constTime.Id)
                {
                    parsipient.IdTeamName = constTime.Id;
                    repository.Update(parsipient);
                    repository.SaveChanges();
                }


                if (gpResult.Note != res.Status.Text)
                {
                    gpResult.Note = res.Status.Text;
                    repository.Update(gpResult);
                    repository.SaveChanges();
                }

                if (gpResult.Classification != res.PositionText)
                {
                    gpResult.Classification = res.PositionText;
                    repository.Update(gpResult);
                    repository.SaveChanges();
                }
            }
        }
    }
}

