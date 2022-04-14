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

//for(var i = 2020; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);
//    //http://ergast.com/api/f1/{{year}}/{{round}}/qualifying
//    for (var j = 1; j <= countGp; j++)
//    {
//        var grandPrixId = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == j).Id;
//        for (var k = 0; k < 900; k += 30)
//        {
//            Console.WriteLine(j.ToString());
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + j.ToString() + "/qualifying?limit=30&offset=" + k.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);
//            XmlSerializer serializer = new XmlSerializer(typeof(MRDataQual));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRDataQual)serializer.Deserialize(reader);
//                if(result.RaceTable.Race is null)
//                {
//                    k = 1000;
//                }
//                else
//                {
//                    var results = result.RaceTable.Race.QualifyingList.QualifyingResult;
//                    foreach (var driver in results)
//                    {
//                        var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == driver.Driver.DriverId);
//                        var participant = repository.Participants
//                            .FirstOrDefault(a => a.IdGrandPrix == grandPrixId && a.IdRacer == racer.Id);
//                        var qua = repository.Qualifications.FirstOrDefault(a => a.IdParticipant == participant.Id);

//                        if(qua is null)
//                        {
//                            string time = "";
//                            if (driver.Q3 != null)
//                                time = driver.Q3;
//                            else if (driver.Q2 != null)
//                                time = driver.Q2;
//                            else
//                                time = driver.Q1;
//                            if (time is null)
//                                time = "";

//                            var newQua = new Qualification
//                            {
//                                IdParticipant = participant.Id,
//                                IsUpdate = true,
//                                Position = Convert.ToInt32(driver.Position),
//                                Time = time
//                            };
//                            repository.Add(newQua);
//                            repository.SaveChanges();
//                        }
//                        else
//                        {
//                            qua.IsUpdate = true;
//                            if (qua.Position != Convert.ToInt32(driver.Position))
//                                qua.Position = Convert.ToInt32(driver.Position);
//                            repository.Update(qua);
//                            repository.SaveChanges();
//                        }
//                    }
//                }
//            }
//        }
//    }
//}

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

for (var i = 1951; i <= 2022; i++)
{
    Console.WriteLine(i.ToString());
    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);

    for (var numGp = 1; numGp <= countGp; numGp++)
    {
        Console.WriteLine(numGp.ToString());
        var grandPrixDb = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == numGp);
        for (var j = 0; j < 900; j += 30)
        {
            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + numGp.ToString() + "/results?limit=30&offset=" + j.ToString();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(path);

            XmlSerializer serializer = new XmlSerializer(typeof(MRData));
            using (StringReader reader = new StringReader(document.Source.Text))
            {
                var result = (MRData)serializer.Deserialize(reader);
                if(result.RaceTable.Race != null)
                {
                    var participants = result.RaceTable.Race.ResultsList.Result;
                    foreach(var participant in participants)
                    {
                        var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == participant.Driver.DriverId);
                        var participantDb = repository.Participants
                            .FirstOrDefault(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id && a.Number == participant.Number);
                        var gpResult = repository.GrandPrixResults.Where(a => a.IdParticipant == participantDb.Id).ToArray();
                        var qua = repository.Qualifications
                            .Where(a => a.IdParticipant == participantDb.Id && a.Participant.Number == participant.Number).ToArray();
                        if(gpResult.Length == 1)
                        {
                            foreach (var res in gpResult)
                            {
                                if (res.Classification != participant.Status.Text)
                                    res.Classification = participant.Status.Text;
                                if (res.Position != Convert.ToInt32(participant.Position))
                                    res.Position = Convert.ToInt32(participant.Position);
                                if (res.Points != (float)Convert.ToDecimal(participant.Points))
                                    res.Points = (float)Convert.ToDecimal(participant.Points);
                                repository.Update(res);
                                repository.SaveChanges();
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                        }

                        if (qua.Length == 1)
                        {
                            foreach (var q in qua)
                            {
                                if (q.Position != Convert.ToInt32(participant.Grid))
                                    q.Position = Convert.ToInt32(participant.Grid);
                                q.IsUpdate = true;
                                repository.Update(q);
                                repository.SaveChanges();
                            }
                        }
                        else if (qua.Length > 1)
                        {
                            bool isRemove = false;
                            foreach (var qu in qua)
                            {
                                if(isRemove == false)
                                {
                                    if (qu.Position != Convert.ToInt32(participant.Grid))
                                        qu.Position = Convert.ToInt32(participant.Grid);
                                    qu.IsUpdate = true;
                                    repository.Update(qu);
                                    repository.SaveChanges();
                                    isRemove = true;
                                }
                                else
                                {
                                    repository.Remove(qu);
                                    repository.SaveChanges();
                                }
                            }
                        }
                        else if(gpResult[0].Lap == Convert.ToInt32(participant.Laps) && qua.Length == 0)
                        {
                            var newQua = new Qualification
                            {
                                IdParticipant = participantDb.Id,
                                IsUpdate = true,
                                Position = Convert.ToInt32(participant.Grid),
                                Time = ""
                            };
                            repository.Add(newQua);
                            repository.SaveChanges();
                        }
                    }
                }
                else
                {
                    j = 1000;
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

