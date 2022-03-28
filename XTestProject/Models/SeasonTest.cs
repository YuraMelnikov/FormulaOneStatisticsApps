using Entities.Models;
using Services.DTO;
using Services.EntityService;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XTestProject.Models
{
    public class SeasonTest : BaseTest
    {
        #region THEORY
        #endregion

        #region FACT

        [Fact]
        public void Fact_PostSeason()
        {
            Guid id = Guid.NewGuid();
            Guid idImage = Guid.NewGuid();
            int year = 1950;

            var seasonsAddedList = new List<Season>() {
                new Season() { Id = id, IdImage = idImage, Year = year }, 
                new Season() { Id = Guid.NewGuid(), IdImage = Guid.NewGuid(), Year = 1951 },
                new Season() { Id = Guid.NewGuid(), IdImage = Guid.NewGuid(), Year = 1952 },
                new Season() { Id = Guid.NewGuid(), IdImage = Guid.NewGuid(), Year = 1953 },
                new Season() { Id = Guid.NewGuid(), IdImage = Guid.NewGuid(), Year = 1950 },
            };


            var season = new Season { Id = id, IdImage = idImage, Year = year };
            _context.Seasons.Add(season);
            _context.SaveChanges();

            var p = _context.Seasons.Count();

            Assert.Equal(id, season.Id);
            Assert.Equal(idImage, season.IdImage);
            Assert.Equal(year, season.Year);
        }


        #endregion
    }
}
