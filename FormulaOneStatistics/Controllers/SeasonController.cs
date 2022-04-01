using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Services.IService;
using System.Xml;
using System.Xml.Serialization;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SeasonController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("calendar/{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            //https://ergast.com/api/f1/1950/7/driverStandings
            //https://ergast.com/api/f1/1950/7/constructorStandings

            for (var i = 1950; i <= 2019; i++)
            {
                string startPage = "https://ergast.com/api/f1/1950/7/driverStandings";

                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                IDocument document = await context.OpenAsync(startPage);



                var xml = document.Source.Text;



                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlSerializer ser = new XmlSerializer(typeof(object));
                using (StreamReader sr = new StreamReader(xml))
                {
                    var n = ser.Deserialize(sr);
                }


                //var tableRacers = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                //var tableRacers = document.QuerySelectorAll("#mw-content-text > div > div.table-wide > div > table").ToList();
                var tableRacers = document.QuerySelectorAll("#content > div > div > div > table > tbody > tr").ToList();
                ////*[@id="mw-content-text"]/div/div[3]/div/table
                ///
            }






            var calendar = await _service.Season.GetClendar(id);
            return Ok(calendar);
        }

        [HttpGet("teams/{id}")]
        public async Task<IActionResult> GetTeams(Guid id)
        {
            var teams = await _service.Season.GetPercipient(id);
            return Ok(teams);
        }

        [HttpGet("championshipracers/{id}")]
        public async Task<IActionResult> GetChampionshipResultRacers(Guid id)
        {
            var racersResult = await _service.Season.GetChampionshipRacers(id);
            return Ok(racersResult);
        }

        [HttpGet("championshipteams/{id}")]
        public async Task<IActionResult> GetChampionshipResultTeams(Guid id)
        {
            var teamsResult = await _service.Season.GetChampionshipTeams(id);
            return Ok(teamsResult);
        }
    }
}
