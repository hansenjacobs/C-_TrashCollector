using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class WeekDay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string AbbreviationShort { get; set; }

        [Required]
        [StringLength(2)]
        public string AbbreviationMedium { get; set; }

        [Required]
        [StringLength(3)]
        public string AbbreviationLong { get; set; }

        [Required]
        public bool AreOperating { get; set; }

        public static IEnumerable<WeekDay> GetOperatingDay(ApplicationDbContext _context)
        {
            return _context.WeekDays.Where(w => w.AreOperating == true).ToList();
        }
    }
}