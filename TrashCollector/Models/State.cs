using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string AbbreviationShort { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public static State AddState (ApplicationDbContext _context, State state)
        {
            var newState = new State()
            {
                Name = state.Name,
                AbbreviationShort = state.Name
            };

            _context.States.Add(newState);
            _context.SaveChanges();

            return newState;
        }

        public static string GetStateNameById (ApplicationDbContext _conext, int id)
        {
            return _conext.States.Single(s => s.Id == id).Name;
        }

        public static IEnumerable<State> GetStates(ApplicationDbContext _context)
        {
            return _context.States.ToList();
        }

        public static int GetStateId(ApplicationDbContext _context, State state)
        {
            var result = _context.States
                .Where(s => s.Name == state.Name)
                .SingleOrDefault();

            return result == null ? 0 : result.Id;
        }
    }
}