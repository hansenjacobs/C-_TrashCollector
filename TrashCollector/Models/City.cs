using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        public static City AddCity (ApplicationDbContext _context, City city)
        {
            var newCity = new City()
            {
                Name = city.Name,
                StateId = State.GetStateId(_context, city.State)
            };

            if (newCity.StateId == 0)
            {
                newCity.State = State.AddState(_context, city.State);
                newCity.StateId = newCity.State.Id;
            }

            _context.Cities.Add(newCity);
            _context.SaveChanges();

            return newCity;
        }

        public static int GetCityId (ApplicationDbContext _context, City city)
        {
            var result = _context.Cities
                .Include(c => c.State)
                .Where(c => c.Name == city.Name && c.State.Name == city.State.Name)
                .SingleOrDefault();

            return result == null ? 0 : result.Id;
        }
    }
}