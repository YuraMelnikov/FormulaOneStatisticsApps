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

string[] allfiles = Directory.GetFiles($"D:\\Downloads\\");
var resultList = new List<ImageData>();
int count = 0;
int bad = 0;

foreach (var file in allfiles)
{
    count++;

    string stringForAnalis = file.Substring(file.IndexOf('_') + 1);
    for(var i = 0; i < 3; i++)
        stringForAnalis = stringForAnalis.Replace("__", "_");
    stringForAnalis = stringForAnalis.Substring(0, stringForAnalis.IndexOf("by_f1_history") - 1);

    stringForAnalis = stringForAnalis.Replace("hungary", "Hungarian");
    stringForAnalis = stringForAnalis.Replace("france", "French");
    stringForAnalis = stringForAnalis.Replace("japan", "Japanese");
    stringForAnalis = stringForAnalis.Replace("malaysia", "Malaysian");
    stringForAnalis = stringForAnalis.Replace("belgium", "Belgian");
    stringForAnalis = stringForAnalis.Replace("portugal", "Portuguese");
    stringForAnalis = stringForAnalis.Replace("germany", "German");
    stringForAnalis = stringForAnalis.Replace("austria", "Austrian");
    stringForAnalis = stringForAnalis.Replace("australia", "Australian");
    stringForAnalis = stringForAnalis.Replace("spain", "Spanish");
    stringForAnalis = stringForAnalis.Replace("brazil", "Brazilian");
    stringForAnalis = stringForAnalis.Replace("italy", "Italian");
    stringForAnalis = stringForAnalis.Replace("canada", "Canadian");
    stringForAnalis = stringForAnalis.Replace("europe", "European");
    stringForAnalis = stringForAnalis.Replace("marino", "San Marino");
    stringForAnalis = stringForAnalis.Replace("africa", "South African");
    stringForAnalis = stringForAnalis.Replace("britain", "British");
    stringForAnalis = stringForAnalis.Replace("austraia", "Austrian");
    stringForAnalis = stringForAnalis.Replace("mexico", "Mexican");
    stringForAnalis = stringForAnalis.Replace("Australiann", "Australian");
    stringForAnalis = stringForAnalis.Replace("netherlands", "Dutch");
    stringForAnalis = stringForAnalis.Replace("Europeanan", "European");
    stringForAnalis = stringForAnalis.Replace("united_states_west", "United States West");
    stringForAnalis = stringForAnalis.Replace("Europeangrand", "European");
    stringForAnalis = stringForAnalis.Replace("united_states", "United States");
    stringForAnalis = stringForAnalis.Replace("sweden", "Swedish");
    stringForAnalis = stringForAnalis.Replace("Japaneseese", "Japanese");
    stringForAnalis = stringForAnalis.Replace("Brazilianian", "Brazilian");
    stringForAnalis = stringForAnalis.Replace("South Africann", "South African");
    stringForAnalis = stringForAnalis.Replace("britian", "British");
    stringForAnalis = stringForAnalis.Replace("Austriann", "Austrian");
    stringForAnalis = stringForAnalis.Replace("Dutchs", "Dutch");
    stringForAnalis = stringForAnalis.Replace("caesars_palace", "Caesars Palace");
    stringForAnalis = stringForAnalis.Replace("brazi", "Brazilian");
    stringForAnalis = stringForAnalis.Replace("Dutch1979", "Dutch_1979");
    stringForAnalis = stringForAnalis.Replace("United States_1983", "Detroit_1983");
    stringForAnalis = stringForAnalis.Replace("United States_1982", "Caesars Palace_1982");
    stringForAnalis = stringForAnalis.Replace("United States_1981", "Caesars Palace_1981");
    stringForAnalis = stringForAnalis.Replace("United States_grand_prix_west_start", "United States West");
    stringForAnalis = stringForAnalis.Replace("United States_gp_1983", "Detroit_1983");
    stringForAnalis = stringForAnalis.Replace("usa_1983", "Detroit_1983");
    stringForAnalis = stringForAnalis.Replace("usa_1982", "Caesars Palace_1982");
    stringForAnalis = stringForAnalis.Replace("usa_1981", "Caesars Palace_1981");
    stringForAnalis = stringForAnalis.Replace("usa", "United States");
    stringForAnalis = stringForAnalis.Replace("United States_1988", "Detroit_1988");
    stringForAnalis = stringForAnalis.Replace("British1983", "British_1983");
    stringForAnalis = stringForAnalis.Replace("Brazilian1973", "Brazilian");
    stringForAnalis = stringForAnalis.Replace("nurburgring", "German");
    stringForAnalis = stringForAnalis.Replace("1983_United States_grand_prix_west", "United States West_1983");
    stringForAnalis = stringForAnalis.Replace("British1969", "British_1969");
    stringForAnalis = stringForAnalis.Replace("daytona", "United States");
    stringForAnalis = stringForAnalis.Replace("untied_states_1982", "Caesars Palace_1982");
    stringForAnalis = stringForAnalis.Replace("untied_states_1978", "United States_1978");
    stringForAnalis = stringForAnalis.Replace("morocco", "Moroccan");
    stringForAnalis = stringForAnalis.Replace("united_staes_1982", "Caesars Palace_1982");
    stringForAnalis = stringForAnalis.Replace("donington_park_1981", "British_1981");
    stringForAnalis = stringForAnalis.Replace("brabham_bt", "brabham bt");
    stringForAnalis = stringForAnalis.Replace("mclaren_m", "mclaren m");
    stringForAnalis = stringForAnalis.Replace("_uk_", "_British_");

    stringForAnalis = stringForAnalis.Replace("stirling_mos", "stirling");
    stringForAnalis = stringForAnalis.Replace("graham_hill", "graham");
    stringForAnalis = stringForAnalis.Replace("john_surtees", "surtees");
    stringForAnalis = stringForAnalis.Replace("phil_hill", "phil");
    stringForAnalis = stringForAnalis.Replace("tony_maggs", "maggs");
    stringForAnalis = stringForAnalis.Replace("dan_gurney", "gurney");
    stringForAnalis = stringForAnalis.Replace("tony_brooks", "brooks");
    stringForAnalis = stringForAnalis.Replace("_tony_vandervell_", "_");
    stringForAnalis = stringForAnalis.Replace("jackie_stewart", "stewart");
    stringForAnalis = stringForAnalis.Replace("mike_kranefuss", "");
    stringForAnalis = stringForAnalis.Replace("hans_binder", "binder");
    stringForAnalis = stringForAnalis.Replace("hans_joachim_stuck", "stuck");
    stringForAnalis = stringForAnalis.Replace("patrick_depailler", "depailler");
    stringForAnalis = stringForAnalis.Replace("p_hill", "Phil");
    stringForAnalis = stringForAnalis.Replace("mike_hawthorn", "hawthorn");
    stringForAnalis = stringForAnalis.Replace("phill_hill", "phill");
    stringForAnalis = stringForAnalis.Replace("patrick_tambay", "tambay");
    stringForAnalis = stringForAnalis.Replace("mike_parkes", "parkes");
    stringForAnalis = stringForAnalis.Replace("mika_hakkinen", "hakkinen");
    stringForAnalis = stringForAnalis.Replace("john_miles", "miles");
    stringForAnalis = stringForAnalis.Replace("r_schumacher", "ralf");
    stringForAnalis = stringForAnalis.Replace("jack_brabham", "brabham");
    stringForAnalis = stringForAnalis.Replace("ian_scheckter", "scheckter");
    stringForAnalis = stringForAnalis.Replace("jo_siffert", "siffert");
    stringForAnalis = stringForAnalis.Replace("wilson_fittipaldi", "wilson");
    stringForAnalis = stringForAnalis.Replace("roberto_guerrero", "guerrero");
    stringForAnalis = stringForAnalis.Replace("riccardo_paletti", "paletti");
    stringForAnalis = stringForAnalis.Replace("philippe_alliot", "alliot");
    stringForAnalis = stringForAnalis.Replace("piero_taruffi", "taruffi");
    stringForAnalis = stringForAnalis.Replace("philippe_alliot", "alliot");
    stringForAnalis = stringForAnalis.Replace("jim_clark", "clark");
    stringForAnalis = stringForAnalis.Replace("wolfgang_von_trips", "trips");
    stringForAnalis = stringForAnalis.Replace("bruce_mclaren", "mclaren");
    stringForAnalis = stringForAnalis.Replace("peter_gethin", "gethin");
    stringForAnalis = stringForAnalis.Replace("peter_arundell", "arundell");
    stringForAnalis = stringForAnalis.Replace("peter_gethin", "gethin");
    stringForAnalis = stringForAnalis.Replace("peter_revson", "revson");
    stringForAnalis = stringForAnalis.Replace("patrick_neve", "neve");
    stringForAnalis = stringForAnalis.Replace("mike_hailwood", "hailwood");
    stringForAnalis = stringForAnalis.Replace("schumacher", "schumacher");
    stringForAnalis = stringForAnalis.Replace("ralf_schumacher", "ralf");
    stringForAnalis = stringForAnalis.Replace("patrick_head", "");
    stringForAnalis = stringForAnalis.Replace("frank_williams", "");
    stringForAnalis = stringForAnalis.Replace("scumacher", "schumacher");
    stringForAnalis = stringForAnalis.Replace("mike_spence", "spence");
    stringForAnalis = stringForAnalis.Replace("mika_salo", "salo");
    stringForAnalis = stringForAnalis.Replace("williams_schumacher", "ralf");
    stringForAnalis = stringForAnalis.Replace("pedro_lamy", "lamy");
    stringForAnalis = stringForAnalis.Replace("michael_schumacher", "schumacher");
    stringForAnalis = stringForAnalis.Replace("stefan_johansson", "johansson");
    stringForAnalis = stringForAnalis.Replace("martin_donnelly", "donnelly");
    stringForAnalis = stringForAnalis.Replace("pedro_diniz", "diniz");
    stringForAnalis = stringForAnalis.Replace("riccardo_patrese", "patrese");
    stringForAnalis = stringForAnalis.Replace("luigi_musso", "musso");
    stringForAnalis = stringForAnalis.Replace("g_hill", "Graham");
    stringForAnalis = stringForAnalis.Replace("john_taylor", "taylor");
    stringForAnalis = stringForAnalis.Replace("chris_amon", "amon");
    stringForAnalis = stringForAnalis.Replace("jo_bonnier", "bonnier");
    stringForAnalis = stringForAnalis.Replace("aguri_suzuki", "aguri");
    stringForAnalis = stringForAnalis.Replace("alberto_ascari", "ascari");
    stringForAnalis = stringForAnalis.Replace("alex_zanardi", "zanardi");
    stringForAnalis = stringForAnalis.Replace("andrea_de_cesaris", "de_cesaris");
    stringForAnalis = stringForAnalis.Replace("andrea_chiesa", "chiesa");
    stringForAnalis = stringForAnalis.Replace("andrea_montermini", "montermini");
    stringForAnalis = stringForAnalis.Replace("david_coulthard", "coulthard");
    stringForAnalis = stringForAnalis.Replace("david_brabham", "brabham");
    stringForAnalis = stringForAnalis.Replace("david_purley", "purley");
    stringForAnalis = stringForAnalis.Replace("derek_warwick", "warwick");
    stringForAnalis = stringForAnalis.Replace("derek_daly", "daly");
    stringForAnalis = stringForAnalis.Replace("graham_mcrae", "mcrae");
    stringForAnalis = stringForAnalis.Replace("carlos_pace", "pace");
    stringForAnalis = stringForAnalis.Replace("jean_christophe_boullion", "boullion");
    stringForAnalis = stringForAnalis.Replace("jean_marc_gounon", "gounon");
    stringForAnalis = stringForAnalis.Replace("michael_andretti", "andretti");
    stringForAnalis = stringForAnalis.Replace("mike_beuttler", "beuttler");
    stringForAnalis = stringForAnalis.Replace("mike_wilds", "wilds");
    stringForAnalis = stringForAnalis.Replace("carlos_reutemann", "reutemann");
    stringForAnalis = stringForAnalis.Replace("carlos_pace", "pace");
    stringForAnalis = stringForAnalis.Replace("olivier_beretta", "beretta");
    stringForAnalis = stringForAnalis.Replace("olivier_panis", "panis");
    stringForAnalis = stringForAnalis.Replace("pedro_de_la_rosa", "de la Rosa");
    stringForAnalis = stringForAnalis.Replace("philippe_streiff", "streiff");
    stringForAnalis = stringForAnalis.Replace("roberto_moreno", "moreno");
    stringForAnalis = stringForAnalis.Replace("carlos_pace", "pace");
    stringForAnalis = stringForAnalis.Replace("stefan_bellof", "bellof");
    stringForAnalis = stringForAnalis.Replace("tom_pryce", "pryce");
    stringForAnalis = stringForAnalis.Replace("tom_belso", "belso");
    stringForAnalis = stringForAnalis.Replace("tony_trimmer", "trimmer");
    stringForAnalis = stringForAnalis.Replace("tony_brise", "brise");
    stringForAnalis = stringForAnalis.Replace("trevor_taylor", "taylor");



    string[] words = stringForAnalis.Split('_');

    var years = Regex.Matches(stringForAnalis, @"(?=(\d{4}))")
                .Cast<Match>()
                .Select(p => p.Groups[1].Value)
                .ToList();
    ImageData image = default;

    Guid IdSeason = default;
    foreach (var year in years)
    {
        int season = Convert.ToInt32(year);
        if (season > 1949)
        {
            if(season < 2023)
            {
                IdSeason = repository.Seasons.First(a => a.Year == season).Id;
                image = new ImageData { IdSeason = IdSeason};
                resultList.Add(image);
            }
        }
    }
    if (image == default)
        continue;
    var listGrandPrixes = repository.GrandPrixes
        .AsNoTracking()
        .Where(a => a.IdSeason == IdSeason)
        .ToArray();
    foreach(var gp in listGrandPrixes)
    {
        var finding = gp.Name.ToUpper().Replace(" GRAND PRIX", "");
        foreach (var word in words)
        {
            if (finding == word.ToUpper())
                image.IdGrandPrix = gp.Id;
        }
    }

    image.OldLink = file;
    image.Racers = new List<Guid>();
    var racersOnSeasons = repository.Participants
        .AsNoTracking()
        .Where(a => a.GrandPrix.IdSeason == image.IdSeason)
        .GroupBy(a => a.IdRacer)
        .Select(a => a.Key)
        .ToList();
    var racersFullList = new List<Guid>();
    foreach (var racerId in racersOnSeasons)
    {
        var racer = repository.Racers.Find(racerId);
        foreach (var word in words)
        {
            if (word.ToUpper() == racer.FirstName.ToUpper() | word.ToUpper() == racer.SecondName.ToUpper())
            {
                racersFullList.Add(racer.Id);
            }
        }
    }
    var groupRacers = racersFullList.GroupBy(a => a).ToList();
    if(groupRacers.Count > 0)
    {
        foreach (var tmpRacer in groupRacers)
        {
            image.Racers.Add(tmpRacer.Key);
        }
    }

    var newPath = "D:\\Downloads1\\" + count.ToString() + "_newdatapool" + ".jpg";
    var newPathLink = "/" + count.ToString() + "_newdatapool" + ".jpg";
    File.Copy(file, newPath);

    Image newImage = new Image { Link = newPathLink };
    repository.Add(newImage);
    repository.SaveChanges();

    if(image.IdGrandPrix != default)
    {
        GrandPrixImg grandPrixImg = new GrandPrixImg
        {
            IdGrandPrix = image.IdGrandPrix,
            IdImage = newImage.Id
        };
        repository.Add(grandPrixImg);
        repository.SaveChanges();
    }
    else
    {
        SeasonImg grandPrixImg = new SeasonImg
        {
            IdSeason = image.IdSeason,
            IdImage = newImage.Id
        };
        repository.Add(grandPrixImg);
        repository.SaveChanges();
    }

    foreach(var racerId in image.Racers)
    {
        RacerImg newRacerImg = new RacerImg
        {
            IdImage = newImage.Id,
            IdRacer = racerId
        };
        repository.Add(newRacerImg);
        repository.SaveChanges();

        if(image.IdGrandPrix != default)
        {
            var participant = repository.Participants
                .FirstOrDefault(a => a.IdGrandPrix == image.IdGrandPrix && a.IdRacer == racerId);
            try
            {

                ParticipantImg participantImg = new ParticipantImg
                {
                    IdImage = newImage.Id,
                    IdParticipant = participant.Id
                };
                repository.Add(participantImg);
                repository.SaveChanges();
            }
            catch
            {
                bad++;
            }
        }
    }


    //+GrandPrixImg => GrandPrix => Season/Track/TrackСonfiguration
    //+ParticipantImg => ChassisImg => Chassis
    //+RacerImg => Racer
}



var t = 0;



//int count = 0;


//for (var i = 1950; i <= 2019; i++)
//{
//    Console.WriteLine(i.ToString());
//    var idSeason = repository.Seasons.First(a => a.Year == i).Id;
//    var countGp = repository.GrandPrixes.Count(a => a.IdSeason == idSeason);

//    for(var j = 1; j <= countGp; j++)
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
//            if(test.RaceTable.Race.RaceName != grandPrix.FullName)
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
//                try
//                {
//                    gpResult = repository.GrandPrixResults.FirstOrDefault(s => s.IdParticipant == parsipient.Id);
//                    if (parsipient is null | gpResult is null)
//                    {
//                        Console.WriteLine(count.ToString());

//                        count++;

//                        parsipient = repository.Participants
//                            .Include(a => a.Racer)
//                            .Include(a => a.Tyre)
//                            .Include(a => a.Chassis)
//                            .Include(a => a.Engine)
//                            .FirstOrDefault(a => a.IdGrandPrix == grandPrix.Id && a.Racer.TimeApiId == res.Driver.DriverId);
//                        gpResult = repository.GrandPrixResults
//                            .FirstOrDefault(s => s.IdParticipant == parsipient.Id);
//                    }

//                    var constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
//                    if (constTime is null)
//                    {
//                        var newTimeName = new TeamName
//                        {
//                            Name = res.Constructor.Name,
//                            TimeApiId = res.Constructor.ConstructorId,
//                            IdCountry = repository.Countries.FirstOrDefault(a => a.Name == res.Constructor.Nationality).Id
//                        };
//                        repository.Add(newTimeName);
//                        repository.SaveChanges();
//                        constTime = repository.TeamNames.FirstOrDefault(a => a.TimeApiId == res.Constructor.ConstructorId);
//                    }
//                    if (parsipient.IdTeamName != constTime.Id)
//                    {
//                        parsipient.IdTeamName = constTime.Id;
//                        repository.Update(parsipient);
//                        repository.SaveChanges();
//                    }


//                    if (gpResult.Note != res.Status.Text)
//                    {
//                        gpResult.Note = res.Status.Text;
//                        repository.Update(gpResult);
//                        repository.SaveChanges();
//                    }

//                    if (gpResult.Classification != res.PositionText)
//                    {
//                        gpResult.Classification = res.PositionText;
//                        repository.Update(gpResult);
//                        repository.SaveChanges();
//                    }
//                }
//                catch
//                {
//                }



//            }






//        }
//    }
//}

