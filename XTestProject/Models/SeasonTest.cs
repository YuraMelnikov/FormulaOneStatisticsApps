using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach(var data in seasonsAddedList)
            {
                _context.Seasons.Add(data);
                _context.SaveChanges();
            }

            var p = _context.Seasons.Count();
            var t = _context.Seasons.First();

            Assert.Equal(id, t.Id);
            Assert.Equal(idImage, t.IdImage);
            Assert.Equal(year, t.Year);
        }


        #endregion
    }
}
