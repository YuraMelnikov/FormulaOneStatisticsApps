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

var livery = repository.Chassis.ToArray();
foreach(var ch in livery)
{
    var img = repository.Images.Find(ch.IdLivery);
    if(img.Link.Length > 36)
    {
        Console.WriteLine("/assets/livery/" + img.Link.Substring(51));
        img.Link = "/assets/livery/" + img.Link.Substring(51);
        repository.Update(img);
        repository.SaveChanges();
    }
}



#region ChampContsByGp
//for (var i = 1958; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);
//    //http://ergast.com/api/f1/{{year}}/{{round}}/driverStandings
//    for (var j = 1; j <= countGp; j++)
//    {
//        var grandPrixId = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == j).Id;
//        for (var k = 0; k < 900; k += 30)
//        {
//            Console.WriteLine(j.ToString());
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + j.ToString() + "/constructorStandings?limit=30&offset=" + k.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);
//            XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampTeam));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRDataChampTeam)serializer.Deserialize(reader);
//                if (result.StandingsTable.StandingsList is null)
//                {
//                    k = 1000;
//                }
//                else
//                {
//                    var resList = result.StandingsTable.StandingsList.ConstructorStanding;
//                    foreach (var r in resList)
//                    {
//                        var racerId = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == r.Constructor.ConstructorId).Id;
//                        var newCl = new ChampConstructorPastRace
//                        {
//                            IdGrandPrix = grandPrixId,
//                            Position = Convert.ToInt32(r.Position),
//                            Points = (float)Convert.ToDecimal(r.Points.Replace(".", ",")),
//                            IdTeamName = racerId
//                        };
//                        repository.Add(newCl);
//                        repository.SaveChanges();
//                    }
//                }
//            }
//        }
//    }
//}
#endregion

#region ChampRacersByGp
//for (var i = 2011; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);
//    //http://ergast.com/api/f1/{{year}}/{{round}}/driverStandings
//    for (var j = 1; j <= countGp; j++)
//    {
//        var grandPrixId = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == j).Id;
//        for (var k = 0; k < 900; k += 30)
//        {
//            Console.WriteLine(j.ToString());
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + j.ToString() + "/driverStandings?limit=30&offset=" + k.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);
//            XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampRacers));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRDataChampRacers)serializer.Deserialize(reader);
//                if (result.StandingsTable.StandingsList is null)
//                {
//                    k = 1000;
//                }
//                else
//                {
//                    var resList = result.StandingsTable.StandingsList.DriverStanding;
//                    foreach (var r in resList)
//                    {
//                        var racerId = repository.Racers.FirstOrDefault(a => a.TimeApiId == r.Driver.DriverId).Id;
//                        var newCl = new ChampRacersPastRace
//                        {
//                            IdGrandPrix = grandPrixId,
//                            Position = Convert.ToInt32(r.Position),
//                            Points = (float)Convert.ToDecimal(r.Points.Replace(".", ",")),
//                            IdRacer = racerId
//                        };
//                        repository.Add(newCl);
//                        repository.SaveChanges();
//                    }
//                }
//            }
//        }
//    }
//}
#endregion

#region SeasonManufChamp
//for (var i = 1958; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);
//    //http://ergast.com/api/f1/1950/constructorStandings?limit=30&offset=30

//    for (var k = 0; k < 900; k += 30)
//    {
//        string path = "http://ergast.com/api/f1/" + i.ToString() + "/constructorStandings?limit=30&offset=" + k.ToString();
//        var config = Configuration.Default.WithDefaultLoader();
//        var context = BrowsingContext.New(config);
//        IDocument document = await context.OpenAsync(path);
//        XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampTeam));
//        using (StringReader reader = new StringReader(document.Source.Text))
//        {
//            var result = (MRDataChampTeam)serializer.Deserialize(reader);
//            if (result.StandingsTable.StandingsList is null)
//            {
//                k = 1000;
//            }
//            else
//            {
//                var resList = result.StandingsTable.StandingsList.ConstructorStanding;
//                foreach (var r in resList)
//                {
//                    var racerId = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == r.Constructor.ConstructorId).Id;
//                    var newCl = new SeasonManufacturersClassification
//                    {
//                        IdSeason = seasonId,
//                        Position = Convert.ToInt32(r.Position),
//                        Points = (float)Convert.ToDecimal(r.Points.Replace(".", ",")),
//                        IdTeamName = racerId
//                    };
//                    repository.Add(newCl);
//                    repository.SaveChanges();
//                }
//            }
//        }
//    }
//}
#endregion

#region SeasonRacersChamp
//for (var i = 1950; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);
//    //http://ergast.com/api/f1/1950/driverstandings?limit=30&offset=30

//    for (var k = 0; k < 900; k += 30)
//    {
//        string path = "http://ergast.com/api/f1/" + i.ToString() + "/driverstandings?limit=30&offset=" + k.ToString();
//        var config = Configuration.Default.WithDefaultLoader();
//        var context = BrowsingContext.New(config);
//        IDocument document = await context.OpenAsync(path);
//        XmlSerializer serializer = new XmlSerializer(typeof(MRDataChampRacers));
//        using (StringReader reader = new StringReader(document.Source.Text))
//        {
//            var result = (MRDataChampRacers)serializer.Deserialize(reader);
//            if(result.StandingsTable.StandingsList is null)
//            {
//                k = 1000;
//            }
//            else
//            {
//                var resList = result.StandingsTable.StandingsList.DriverStanding;
//                foreach (var r in resList)
//                {
//                    var racerId = repository.Racers.FirstOrDefault(a => a.TimeApiId == r.Driver.DriverId).Id;
//                    var newCl = new SeasonRacersClassification
//                    {
//                        IdSeason = seasonId,
//                        Position = Convert.ToInt32(r.Position),
//                        Points = (float)Convert.ToDecimal(r.Points.Replace(".", ",")),
//                        IdRacer = racerId
//                    };
//                    repository.Add(newCl);
//                    repository.SaveChanges();
//                }
//            }
//        }
//    }
//}
#endregion

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

#region UpdateGpAndQuaResult 1950-1993
//for (var i = 1991; i <= 1993; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);

//    for (var numGp = 1; numGp <= countGp; numGp++)
//    {
//        Console.WriteLine(numGp.ToString());
//        var grandPrixDb = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == numGp);
//        for (var j = 0; j < 900; j += 30)
//        {
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + numGp.ToString() + "/results?limit=30&offset=" + j.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);

//            XmlSerializer serializer = new XmlSerializer(typeof(MRData));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRData)serializer.Deserialize(reader);
//                if (result.RaceTable.Race != null)
//                {
//                    var participants = result.RaceTable.Race.ResultsList.Result;
//                    foreach (var participant in participants)
//                    {
//                        var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == participant.Driver.DriverId);

//                        Guid participantId = default;
//                        var participantDbArrForClear = repository.Participants
//                            .Where(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id && a.Number == participant.Number)
//                            .ToArray();
//                        if (participantDbArrForClear.Length > 1)
//                        {
//                            foreach (var p in participantDbArrForClear)
//                            {
//                                if (repository.GrandPrixResults.FirstOrDefault(a => a.IdParticipant == p.Id && a.ClassificationRus != "нс") != null)
//                                {
//                                    participantId = p.Id;
//                                }
//                            }
//                        }

//                        Participant participantDb;
//                        if (participantId != default)
//                        {
//                            participantDb = repository.Participants.Find(participantId);
//                        }
//                        else
//                        {
//                            participantDb = repository.Participants
//    .FirstOrDefault(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id && a.Number == participant.Number);
//                        }

//                        if (participantDb is null)
//                        {
//                            var participantDbArr = repository.Participants
//                                .Where(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id)
//                                .ToArray();
//                            if (participantDbArr.Length == 1)
//                            {
//                                participantDb = participantDbArr[0];
//                                participantDb.Number = participant.Number;
//                                repository.Update(participantDb);
//                                repository.SaveChanges();
//                            }
//                        }
//                        try
//                        {
//                            var gpResult = repository.GrandPrixResults.Where(a => a.IdParticipant == participantDb.Id && a.ClassificationRus != "нс").ToArray();
//                            var qua = repository.Qualifications
//                                .Where(a => a.IdParticipant == participantDb.Id
//                                && a.Participant.Number == participant.Number).ToArray();
//                            if (gpResult.Length == 1)
//                            {
//                                foreach (var res in gpResult)
//                                {
//                                    if (res.Classification != participant.PositionText)
//                                        res.Classification = participant.PositionText;
//                                    if (res.Note != participant.Status.Text)
//                                        res.Note = participant.Status.Text;
//                                    if (res.Position != Convert.ToInt32(participant.Position))
//                                        res.Position = Convert.ToInt32(participant.Position);
//                                    if (res.Points != (float)Convert.ToDecimal(participant.Points.Replace(".", ",")))
//                                        res.Points = (float)Convert.ToDecimal(participant.Points.Replace(".", ","));
//                                    if (res.Time == "" & participant.Time != null)
//                                        res.Time = participant.Time.Text;
//                                    repository.Update(res);
//                                    repository.SaveChanges();
//                                }
//                            }
//                            else if (gpResult.Length > 1)
//                            {
//                                //	where "IdGrandPrix" = '857f6704-e651-47b9-b99c-43f2a6dfdc5c'
//                                //  and "IdRacer" = '89f41d06-31c5-450f-bc24-80f7a7556103'
//                                Console.WriteLine("where \"IdGrandPrix\" = '" + participantDb.IdGrandPrix + "'");
//                                Console.WriteLine("and \"IdRacer\" = '" + participantDb.IdRacer + "'");
//                                Console.WriteLine();
//                            }

//                            if (qua.Length == 1)
//                            {
//                                foreach (var q in qua)
//                                {
//                                    if (q.Position != Convert.ToInt32(participant.Grid))
//                                        q.Position = Convert.ToInt32(participant.Grid);
//                                    q.IsUpdate = true;
//                                    repository.Update(q);
//                                    repository.SaveChanges();
//                                }
//                            }
//                            else if (qua.Length > 1)
//                            {
//                                bool isRemove = false;
//                                foreach (var qu in qua)
//                                {
//                                    if (isRemove == false)
//                                    {
//                                        if (qu.Position != Convert.ToInt32(participant.Grid))
//                                            qu.Position = Convert.ToInt32(participant.Grid);
//                                        qu.IsUpdate = true;
//                                        repository.Update(qu);
//                                        repository.SaveChanges();
//                                        isRemove = true;
//                                    }
//                                    else
//                                    {
//                                        repository.Remove(qu);
//                                        repository.SaveChanges();
//                                    }
//                                }
//                            }
//                            else if (gpResult[0].Lap == Convert.ToInt32(participant.Laps) && qua.Length == 0)
//                            {
//                                var newQua = new Qualification
//                                {
//                                    IdParticipant = participantDb.Id,
//                                    IsUpdate = true,
//                                    Position = Convert.ToInt32(participant.Grid),
//                                    Time = ""
//                                };
//                                repository.Add(newQua);
//                                repository.SaveChanges();
//                            }

//                        }
//                        catch
//                        {
//                            if (participant.Status.Text != "Withdrew" && participant.Laps != "0")
//                            {
//                                Console.WriteLine("where \"IdGrandPrix\" = '" + participantDb.IdGrandPrix + "'");
//                                Console.WriteLine("and \"IdRacer\" = '" + participantDb.IdRacer + "'");
//                                Console.WriteLine();
//                            }

//                        }
//                    }
//                }
//                else
//                {
//                    j = 1000;
//                }



//            }
//        }
//    }
//}
#endregion

#region UpdateGpResult 1994-2019
//for (var i = 1994; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);

//    for (var numGp = 1; numGp <= countGp; numGp++)
//    {
//        Console.WriteLine(numGp.ToString());
//        var grandPrixDb = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == numGp);
//        for (var j = 0; j < 900; j += 30)
//        {
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + numGp.ToString() + "/results?limit=30&offset=" + j.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);

//            XmlSerializer serializer = new XmlSerializer(typeof(MRData));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRData)serializer.Deserialize(reader);
//                if (result.RaceTable.Race != null)
//                {
//                    var participants = result.RaceTable.Race.ResultsList.Result;
//                    foreach (var participant in participants)
//                    {
//                        var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == participant.Driver.DriverId);

//                        Guid participantId = default;
//                        var participantDbArrForClear = repository.Participants
//                            .Where(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id && a.Number == participant.Number)
//                            .ToArray();
//                        if (participantDbArrForClear.Length > 1)
//                        {
//                            foreach (var p in participantDbArrForClear)
//                            {
//                                if (repository.GrandPrixResults.FirstOrDefault(a => a.IdParticipant == p.Id && a.ClassificationRus != "нс") != null)
//                                {
//                                    participantId = p.Id;
//                                }
//                            }
//                        }

//                        Participant participantDb;
//                        if (participantId != default)
//                        {
//                            participantDb = repository.Participants.Find(participantId);
//                        }
//                        else
//                        {
//                            participantDb = repository.Participants
//    .FirstOrDefault(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id && a.Number == participant.Number);
//                        }

//                        if (participantDb is null)
//                        {
//                            var participantDbArr = repository.Participants
//                                .Where(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id)
//                                .ToArray();
//                            if (participantDbArr.Length == 1)
//                            {
//                                participantDb = participantDbArr[0];
//                                participantDb.Number = participant.Number;
//                                repository.Update(participantDb);
//                                repository.SaveChanges();
//                            }
//                        }
//                        try
//                        {
//                            var gpResult = repository.GrandPrixResults.Where(a => a.IdParticipant == participantDb.Id && a.ClassificationRus != "нс").ToArray();
//                            if (gpResult.Length == 1)
//                            {
//                                foreach (var res in gpResult)
//                                {
//                                    if (res.Classification != participant.PositionText)
//                                        res.Classification = participant.PositionText;
//                                    if (res.Note != participant.Status.Text)
//                                        res.Note = participant.Status.Text;
//                                    if (res.Position != Convert.ToInt32(participant.Position))
//                                        res.Position = Convert.ToInt32(participant.Position);
//                                    if (res.Points != (float)Convert.ToDecimal(participant.Points.Replace(".", ",")))
//                                        res.Points = (float)Convert.ToDecimal(participant.Points.Replace(".", ","));
//                                    if (res.Time == "" & participant.Time != null)
//                                        res.Time = participant.Time.Text;
//                                    repository.Update(res);
//                                    repository.SaveChanges();
//                                }
//                            }
//                            else if (gpResult.Length > 1)
//                            {
//                                //	where "IdGrandPrix" = '857f6704-e651-47b9-b99c-43f2a6dfdc5c'
//                                //  and "IdRacer" = '89f41d06-31c5-450f-bc24-80f7a7556103'
//                                Console.WriteLine("where \"IdGrandPrix\" = '" + participantDb.IdGrandPrix + "'");
//                                Console.WriteLine("and \"IdRacer\" = '" + participantDb.IdRacer + "'");
//                                Console.WriteLine();
//                            }
//                        }
//                        catch
//                        {
//                            if (participant.Status.Text != "Withdrew" && participant.Laps != "0")
//                            {
//                                Console.WriteLine("where \"IdGrandPrix\" = '" + participantDb.IdGrandPrix + "'");
//                                Console.WriteLine("and \"IdRacer\" = '" + participantDb.IdRacer + "'");
//                                Console.WriteLine();
//                            }

//                        }
//                    }
//                }
//                else
//                {
//                    j = 1000;
//                }
//            }
//        }
//    }
//}
#endregion

#region Qua 1994 - 2019
//for (var i = 1994; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var seasonId = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == seasonId);

//    for (var numGp = 1; numGp <= countGp; numGp++)
//    {
//        Console.WriteLine(numGp.ToString());
//        var grandPrixDb = repository.GrandPrixes.FirstOrDefault(a => a.IdSeason == seasonId && a.NumberInSeason == numGp);
//        for (var j = 0; j < 900; j += 30)
//        {
//            string path = "http://ergast.com/api/f1/" + i.ToString() + "/" + numGp.ToString() + "/qualifying?limit=30&offset=" + j.ToString();
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);
//            IDocument document = await context.OpenAsync(path);
//            XmlSerializer serializer = new XmlSerializer(typeof(MRDataQual));
//            using (StringReader reader = new StringReader(document.Source.Text))
//            {
//                var result = (MRDataQual)serializer.Deserialize(reader);
//                if (result.RaceTable.Race is null)
//                {
//                    j = 1000;
//                }
//                else
//                {
//                    var results = result.RaceTable.Race.QualifyingList.QualifyingResult;
//                    foreach (var driver in results)
//                    {
//                        var racer = repository.Racers.FirstOrDefault(a => a.TimeApiId == driver.Driver.DriverId);
//                        var participant = repository.Participants.FirstOrDefault(a => a.IdGrandPrix == grandPrixDb.Id && a.IdRacer == racer.Id);
//                        string time = "";
//                        if (driver.Q3 != null)
//                            time = driver.Q3;
//                        else if (driver.Q2 != null)
//                            time = driver.Q2;
//                        else
//                            time = driver.Q1;
//                        if (time is null)
//                            time = "";

//                        var newQua = new Qualification
//                        {
//                            IdParticipant = participant.Id,
//                            IsUpdate = true,
//                            Position = Convert.ToInt32(driver.Position),
//                            Time = time
//                        };
//                        repository.Add(newQua);
//                        repository.SaveChanges();
//                    }
//                }
//            }
//        }
//    }
//}
#endregion