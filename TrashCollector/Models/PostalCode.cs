using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class PostalCode
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 digits")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Zip code can only contain numerical digits.")]
        public string Code { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        public static PostalCode AddPostalCode (ApplicationDbContext _context, PostalCode postalCode)
        {
            var newPostalCode = new PostalCode()
            {
                Code = postalCode.Code,
                CityId = City.GetCityId(_context, postalCode.City)
            };

            if(newPostalCode.CityId == 0)
            {
                newPostalCode.City = City.AddCity(_context, postalCode.City);
                newPostalCode.CityId = newPostalCode.City.Id;
            }

            _context.PostalCodes.Add(newPostalCode);
            _context.SaveChanges();

            return newPostalCode;
        }

        public static int GetPostalCodeId (ApplicationDbContext _context, PostalCode postalCode)
        {
            var result = _context.PostalCodes
                .Include(p => p.City.State)
                .Where(p => p.Code == postalCode.Code
                && p.City.Name == postalCode.City.Name
                && p.City.State.Name == postalCode.City.State.Name).SingleOrDefault();

            return result == null ? 0 : result.Id;
        }
    }
}