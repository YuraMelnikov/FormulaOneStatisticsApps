//https://ergast.com/api/f1/1950/7/driverStandings
//https://ergast.com/api/f1/1950/7/constructorStandings

using AngleSharp;
using AngleSharp.Dom;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Parser;
using System.Xml.Serialization;
using static Parser.ChampXML;
using System.Text.Json;
using System.Text.Json.Serialization;

RepositoryParcer repository = new RepositoryParcer();



#region Update 2020-2022

//for (int i = 2020; i <= 2022; i++)
//{
//    var seasonIdDb = repository.Seasons.FirstOrDefault(s => s.Year == i).Id;
//    for (int j = 0; j < 800; j += 30)
//    {
//        var numLastGp = repository.GrandPrixes.Where(a => a.Season.Year == i).Max(a => a.NumberInSeason);
//        var link = "http://ergast.com/api/f1/" + i.ToString() + "/" + numLastGp.ToString() + "/constructorStandings?limit=30&offset=" + j.ToString();
//        var config = Configuration.Default.WithDefaultLoader();
//        var context = BrowsingContext.New(config);
//        IDocument document = await context.OpenAsync(link);
//        XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampTeam));
//        using (StringReader reader = new StringReader(document.Source.Text))
//        {
//            var result = (MRDataChampTeam)serializer.Deserialize(reader);
//            if (result.StandingsTable.StandingsList is null)
//            {
//                j = 900;
//            }
//            else
//            {
//                var drivers = result.StandingsTable.StandingsList.ConstructorStanding;
//                foreach (var driver in drivers)
//                {
//                    var team = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == driver.Constructor.ConstructorId);
//                    var points = driver.Points.Replace(".", ",");
//                    SeasonManufacturersClassification classification = new SeasonManufacturersClassification
//                    {
//                        IdSeason = seasonIdDb,
//                        IdTeamName = team.Id,
//                        Points = (float)Convert.ToDecimal(points),
//                        Position = Convert.ToInt32(driver.Position)
//                    };
//                    repository.Add(classification);
//                    repository.SaveChanges();
//                }
//            }
//        }
//    }
//}

//for (int i = 1950; i <= 2019; i++)
//{
//    var seasonIdDb = repository.Seasons.FirstOrDefault(s => s.Year == i).Id;
//    for (int j = 0; j < 800; j += 30)
//    {
//        var numLastGp = repository.GrandPrixes.Where(a => a.Season.Year == i).Max(a => a.NumberInSeason);
//        var link = "http://ergast.com/api/f1/" + i.ToString() + "/" + numLastGp.ToString() + "/driverStandings?limit=30&offset=" + j.ToString();
//        var config = Configuration.Default.WithDefaultLoader();
//        var context = BrowsingContext.New(config);
//        IDocument document = await context.OpenAsync(link);

//        XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampRacers));
//        using (StringReader reader = new StringReader(document.Source.Text))
//        {
//            var result = (MRDataChampRacers)serializer.Deserialize(reader);
//            if (result.StandingsTable.StandingsList is null)
//            {
//                j = 900;
//            }
//            else
//            {
//                var drivers = result.StandingsTable.StandingsList.DriverStanding;
//                foreach (var driver in drivers)
//                {
//                    var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == driver.Driver.DriverId);
//                    var points = driver.Points.Replace(".", ",");

//                    SeasonRacersClassification classification = new SeasonRacersClassification
//                    {
//                        IdSeason = seasonIdDb,
//                        IdRacer = racer.Id,
//                        Points = (float)Convert.ToDecimal(points),
//                        Position = Convert.ToInt32(driver.Position)
//                    };
//                    repository.Add(classification);
//                    repository.SaveChanges();
//                }
//            }
//        }
//    }
//}

#endregion

for (var i = 1994; i <= 2022; i++)
{
    Console.WriteLine(i.ToString());
    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);

    for (var numGp = 1; numGp <= countGp; numGp++)
    {
        var grandPrixDb = repository.GrandPrixes
            .FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == numGp);

        string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + numGp.ToString() + "/results";
        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        IDocument document = await context.OpenAsync(path);

        XmlSerializer serializer = new XmlSerializer(typeof(MRData));
        using (StringReader reader = new StringReader(document.Source.Text))
        {
            var result = (MRData)serializer.Deserialize(reader);
            var participants = result.RaceTable.Race.ResultsList.Result;

            foreach (var parcipiant in participants)
            {
                var racerDb = repository.Racers
                    .Where(a => a.TimeApiId == parcipiant.Driver.DriverId)
                    .FirstOrDefault();
                var parcipiantDb = repository.Participants
                    .Include(a => a.Racer)
                    .Include(a => a.Tyre)
                    .Include(a => a.Chassis)
                    .Include(a => a.Engine)
                    .FirstOrDefault(a => a.IdGrandPrix == grandPrixDb.Id
                        && a.Racer.TimeApiId == parcipiant.Driver.DriverId
                        && a.Number == parcipiant.Number
                    );

                if(parcipiantDb != null)
                {
                    var resultDb = repository.GrandPrixResults
                        .FirstOrDefault(a => a.IdParticipant == parcipiantDb.Id);
                    var teamNameId = repository.TeamNames
                        .FirstOrDefault(a => a.TimeApiId == parcipiant.Constructor.ConstructorId).Id;
                    parcipiantDb.IdTeamName = teamNameId;
                    repository.Update(parcipiantDb);
                    repository.SaveChanges();

                    if(resultDb is null)
                    {
                        Console.WriteLine("where \"IdGrandPrix\" = '" + parcipiantDb.IdGrandPrix + "'");
                        Console.WriteLine("and \"IdRacer\" = '" + parcipiantDb.IdRacer + "'");
                    }
                    else
                    {
                        if (resultDb.Time == "" & parcipiant.Time != null)
                            resultDb.Time = parcipiant.Time.Text;
                        repository.Update(resultDb);
                        repository.SaveChanges();
                    }
                    racerDb.Born = Convert.ToDateTime(parcipiant.Driver.DateOfBirth);
                    repository.Update(racerDb);
                    repository.SaveChanges();
                }
                else
                {
                    var listPart = repository.Participants
                        .Include(a => a.Racer)
                        .Include(a => a.Tyre)
                        .Include(a => a.Chassis)
                        .Include(a => a.Engine)
                        .Where(a => a.IdGrandPrix == grandPrixDb.Id
                            && a.Racer.TimeApiId == parcipiant.Driver.DriverId
                        ).ToArray();

                    if(listPart.Length == 1)
                    {
                        parcipiantDb = listPart[0];

                        var teamNameId = repository.TeamNames
    .FirstOrDefault(a => a.TimeApiId == parcipiant.Constructor.ConstructorId).Id;

                        var resultDb = repository.GrandPrixResults
                            .FirstOrDefault(a => a.IdParticipant == parcipiantDb.Id);



                        parcipiantDb.IdTeamName = teamNameId;
                        repository.Update(parcipiantDb);
                        repository.SaveChanges();

                        if (resultDb.Time == "" & parcipiant.Time != null)
                            resultDb.Time = parcipiant.Time.Text;
                        repository.Update(resultDb);
                        repository.SaveChanges();

                        racerDb.Born = Convert.ToDateTime(parcipiant.Driver.DateOfBirth);
                        repository.Update(racerDb);
                        repository.SaveChanges();
                    }
                }

            }
        }
    }
}


//for (var i = 1950; i <= 2022; i++)
//{
//    Console.WriteLine(i.ToString());
//    var idSeason = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == idSeason);

//    for (var j = 1; j <= countGp; j++)
//    {
//        var grandPrix = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == idSeason && a.NumberInSeason == j);

//        string startPage = "http://ergast.com/api/f1/" + i.ToString() + "/" + j.ToString() + "/results";

//        var config = Configuration.Default.WithDefaultLoader();
//        var context = BrowsingContext.New(config);
//        IDocument document = await context.OpenAsync(startPage);

//        XmlSerializer serializer = new XmlSerializer(typeof(MRData));
//        using (StringReader reader = new StringReader(document.Source.Text))
//        {
//            var test = (MRData)serializer.Deserialize(reader);
//            var results = test.RaceTable.Race.ResultsList.Result;
//            if (test.RaceTable.Race.RaceName != grandPrix.FullName)
//            {
//                Console.WriteLine("Name: {0} - {1}", test.RaceTable.Race.RaceName, grandPrix.Name);
//                grandPrix.Name = test.RaceTable.Race.RaceName;
//                repository.Update(grandPrix);
//                repository.SaveChanges();
//            }
//            foreach (var res in results)
//            {
//                var parsipient = repository.Participants
//                    .Include(a => a.Racer)
//                    .Include(a => a.Tyre)
//                    .Include(a => a.Chassis)
//                    .Include(a => a.Engine)
//                    .FirstOrDefault(a => a.IdGrandPrix == grandPrix.Id
//                    && a.Racer.TimeApiId == res.Driver.DriverId
//                    && a.Number == res.Number
//                    );
//                GrandPrixResult gpResult;


//                gpResult = repository.GrandPrixResults.FirstOrDefault(s => s.IdParticipant == parsipient.Id);


//                if (parsipient is null | gpResult is null)
//                {
//                    Console.WriteLine(count.ToString());

//                    count++;

//                    parsipient = repository.Participants
//                        .Include(a => a.Racer)
//                        .Include(a => a.Tyre)
//                        .Include(a => a.Chassis)
//                        .Include(a => a.Engine)
//                        .FirstOrDefault(a => a.IdGrandPrix == grandPrix.Id && a.Racer.TimeApiId == res.Driver.DriverId);
//                    gpResult = repository.GrandPrixResults
//                        .FirstOrDefault(s => s.IdParticipant == parsipient.Id);
//                }

//                var constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
//                if (constTime is null)
//                {
//                    var newTimeName = new TeamName
//                    {
//                        Name = res.Constructor.Name,
//                        TimeApiId = res.Constructor.ConstructorId,
//                        IdCountry = repository.Countries.FirstOrDefault(a => a.Name == res.Constructor.Nationality).Id
//                    };
//                    repository.Add(newTimeName);
//                    repository.SaveChanges();
//                    constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
//                }
//                if (parsipient.IdTeamName != constTime.Id)
//                {
//                    parsipient.IdTeamName = constTime.Id;
//                    repository.Update(parsipient);
//                    repository.SaveChanges();
//                }


//                if (gpResult.Note != res.Status.Text)
//                {
//                    gpResult.Note = res.Status.Text;
//                    repository.Update(gpResult);
//                    repository.SaveChanges();
//                }

//                if (gpResult.Classification != res.PositionText)
//                {
//                    gpResult.Classification = res.PositionText;
//                    repository.Update(gpResult);
//                    repository.SaveChanges();
//                }
//            }
//        }
//    }
//}

