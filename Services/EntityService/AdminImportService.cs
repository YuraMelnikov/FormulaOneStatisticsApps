using Entities.Contexts;
using Entities.Models;
using FastExcel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminImportService : IAdminImportService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminImportService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public bool ImportData(IFormFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Import", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Worksheet worksheet = null;
                using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(path), true))
                {
                    worksheet = fastExcel.Read("TrackСonfiguration");
                    var rows = worksheet.Rows.ToArray()[1].Cells.ToArray();
                    Guid idTrack = _repositoryContext.Tracks.AsNoTracking().First(a => a.Name == rows[0].Value.ToString()).Id;
                    TrackСonfiguration сonfiguration = new TrackСonfiguration 
                    { 
                        IdImage = Guid.Parse(rows[3].ToString()), 
                        IdTrack = idTrack, 
                        Length = Convert.ToInt32(rows[1].Value), 
                        Note = rows[2].ToString()
                    };
                    _repositoryContext.Add(сonfiguration);
                    _repositoryContext.SaveChanges();

                    worksheet = fastExcel.Read("GrandPrix");
                    rows = worksheet.Rows.ToArray()[1].Cells.ToArray();
                    Guid idImage = _repositoryContext.Images.AsNoTracking().First(a => a.Link == DefaulValues.DefaultImage).Id;
                    Guid idGrandPrixName = _repositoryContext.GrandPrixNames.AsNoTracking().First(a => a.FullName == rows[6].Value.ToString()).Id;
                    Guid idSeason = _repositoryContext.Seasons.AsNoTracking().First(a => a.Year == Convert.ToInt32(rows[0].Value)).Id;
                    int number = _repositoryContext.GrandPrixes.AsNoTracking().Max(a => a.Number) + 1;
                    int numberInSeason = _repositoryContext.GrandPrixes.AsNoTracking().Where(a => a.IdSeason == idSeason).Max(a => a.NumberInSeason) + 1;
                    DateTime dateGrandPrix = Convert.ToDateTime(rows[2].ToString());

                    GrandPrix gp = new GrandPrix { 
                        Date = dateGrandPrix, 
                        FullName = rows[3].ToString(), 
                        IdGrandPrixNames = idGrandPrixName, 
                        IdImage = idImage, 
                        IdSeason = idSeason, 
                        IdTrackСonfiguration = сonfiguration.Id, 
                        IdTypeStartField = DefaulValues.TypeStartField, 
                        Number = number, 
                        NumberInSeason = numberInSeason, 
                        NumberOfLap = Convert.ToInt32(rows[5].ToString()), 
                        Text = "", 
                        Weather = rows[4].ToString(), 
                        WeatherRus = rows[7].ToString()
                    };
                    _repositoryContext.Add(gp);
                    _repositoryContext.SaveChanges();

                    worksheet = fastExcel.Read("GrandPrixResult");
                    var col = worksheet.Rows.ToArray();
                    for (int i = 1; i < col.Length; i++)
                    {
                        rows = col[i].Cells.ToArray();
                        Guid idChassis = _repositoryContext.Chassis.AsNoTracking().First(a => a.Name == rows[1].ToString()).Id;
                        Guid idEngine = _repositoryContext.Engines.AsNoTracking().First(a => a.Name == rows[2].ToString()).Id;
                        Guid idRacer = _repositoryContext.Racers.AsNoTracking().First(a => a.TimeApiId == rows[0].ToString()).Id;
                        Guid idTeam = _repositoryContext.Teams.AsNoTracking().First(a => a.Name == rows[19].ToString()).Id;
                        Guid idTeamName = _repositoryContext.TeamNames.AsNoTracking().First(a => a.TimeApiId == rows[18].ToString()).Id;
                        Guid idTyre = _repositoryContext.Tyres.AsNoTracking().First(a => a.Name == rows[3].ToString()).Id;
                        Participant participant = new Participant 
                        { 
                            IdChassis = idChassis, 
                            IdEngine = idEngine, 
                            IdGrandPrix = gp.Id, 
                            IdRacer = idRacer, 
                            IdTeam = idTeam, 
                            IdTeamName = idTeamName, 
                            IdTyre = idTyre, 
                            Number = rows[4].ToString() 
                        };
                        _repositoryContext.Add(participant);
                        _repositoryContext.SaveChanges();
                        GrandPrixResult result = new GrandPrixResult
                        {
                            AverageSpeed = rows[7].ToString(), 
                            Classification = rows[5].ToString(), 
                            ClassificationRus = rows[12].ToString(), 
                            FastestLap = Convert.ToInt32(rows[14].ToString()), 
                            FastestLapSpeed = rows[15].ToString(), 
                            FastestLapTime = rows[16].ToString(), 
                            Lap = Convert.ToInt32(rows[8].ToString()), 
                            IdParticipant = participant.Id,
                            Note = rows[11].ToString(), 
                            NoteRus = rows[13].ToString(), 
                            Points = Convert.ToInt32(rows[9].ToString()), 
                            Position = Convert.ToInt32(rows[10].ToString()),
                            Time = rows[6].ToString(), 
                            TimeLag = rows[17].ToString()
                        };
                        _repositoryContext.Add(result);
                        _repositoryContext.SaveChanges();
                    }

                    worksheet = fastExcel.Read("LapTimes");
                    col = worksheet.Rows.ToArray();
                    for(int i = 1; i < col.Length; i++)
                    {
                        rows = col[i].Cells.ToArray();
                        Guid idParticipantL = _repositoryContext.Participants.AsNoTracking().First(a => a.IdGrandPrix == gp.Id && a.Racer.TimeApiId == rows[0].ToString()).Id;
                        LapTimes lapTimes = new LapTimes 
                        { 
                            IdParticipant = idParticipantL, 
                            Lap = Convert.ToInt32(rows[1].ToString()), 
                            Posotion = Convert.ToInt32(rows[2].ToString()), 
                            Time = rows[3].ToString()
                        };
                        _repositoryContext.Add(lapTimes);
                        _repositoryContext.SaveChanges();
                    }

                    worksheet = fastExcel.Read("Qualification");
                    col = worksheet.Rows.ToArray();
                    for (int i = 1; i < col.Length; i++)
                    {
                        rows = col[i].Cells.ToArray();
                        Guid idParticipantQ = _repositoryContext.Participants.AsNoTracking().First(a => a.IdGrandPrix == gp.Id && a.Racer.TimeApiId == rows[0].ToString()).Id;
                        Qualification qualification = new Qualification
                        {
                            IdParticipant = idParticipantQ, 
                            Position = Convert.ToInt32(rows[1].ToString()), 
                            Time = rows[2].ToString()
                        };
                        _repositoryContext.Add(qualification);
                        _repositoryContext.SaveChanges();
                    }

                    worksheet = fastExcel.Read("GrandprixNote");
                    rows = worksheet.Rows.ToArray()[1].Cells.ToArray();
                    GrandprixNote note = new GrandprixNote
                    {
                        IdGrandPrix = gp.Id, 
                        Note = rows[0].ToString(),
                        NoteRus = rows[1].ToString()
                    };
                    _repositoryContext.Add(note);
                    _repositoryContext.SaveChanges();

                    worksheet = fastExcel.Read("FastLap");
                    rows = worksheet.Rows.ToArray()[1].Cells.ToArray();
                    Guid idParticipant = _repositoryContext.Participants.AsNoTracking().First(a => a.IdGrandPrix == gp.Id && a.Racer.TimeApiId == rows[0].ToString()).Id;
                    FastLap fastLap = new FastLap
                    {
                        IdParticipant = idParticipant, 
                        AverageSpeed = rows[2].ToString(), 
                        Time = rows[1].ToString()
                    };
                    _repositoryContext.Add(fastLap);
                    _repositoryContext.SaveChanges();

                    worksheet = fastExcel.Read("ChampConstructorPastRace");
                    col = worksheet.Rows.ToArray();
                    for (int i = 1; i < col.Length; i++)
                    {
                        rows = col[i].Cells.ToArray();
                        Guid idTeamName = _repositoryContext.TeamNames.AsNoTracking().First(a => a.TimeApiId == rows[0].ToString()).Id;
                        ChampConstructorPastRace champConstructor = new ChampConstructorPastRace
                        { 
                            IdGrandPrix = gp.Id, 
                            IdTeamName = idTeamName, 
                            Points = (float)Convert.ToDecimal(rows[2].ToString()), 
                            Position = Convert.ToInt32(rows[1].ToString())
                        };
                        _repositoryContext.Add(champConstructor);
                        _repositoryContext.SaveChanges();
                    }

                    worksheet = fastExcel.Read("ChampRacersPastRace");
                    col = worksheet.Rows.ToArray();
                    for (int i = 1; i < col.Length; i++)
                    {
                        rows = col[i].Cells.ToArray();
                        Guid idRacer = _repositoryContext.Racers.AsNoTracking().First(a => a.TimeApiId == rows[0].ToString()).Id;
                        ChampRacersPastRace champRacer = new ChampRacersPastRace
                        {
                            IdGrandPrix = gp.Id,
                            IdRacer = idRacer,
                            Points = (float)Convert.ToDecimal(rows[2].ToString()),
                            Position = Convert.ToInt32(rows[1].ToString())
                        };
                        _repositoryContext.Add(champRacer);
                        _repositoryContext.SaveChanges();
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
