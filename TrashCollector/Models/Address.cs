using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }

        [ForeignKey("PostalCode")]
        public int PostalCodeId { get; set; }
        public PostalCode PostalCode { get; set; }

        public static Address AddAddress(ApplicationDbContext _context, Address address)
        {
            var newAddress = new Address()
            {
                AddressLine = address.AddressLine,
                PostalCodeId = PostalCode.GetPostalCodeId(_context, address.PostalCode)
            };

            if(newAddress.PostalCodeId == 0)
            {
                newAddress.PostalCode = PostalCode.AddPostalCode(_context, address.PostalCode);
                newAddress.PostalCodeId = newAddress.PostalCode.Id;
            }

            _context.Addresses.Add(newAddress);
            _context.SaveChanges();

            return newAddress;

        }

        public static int GetAddressId (ApplicationDbContext _context, Address address)
        {
            var result = _context.Addresses
                .Include(a => a.PostalCode.City.State)
                .Where(a => a.PostalCode.Code == address.PostalCode.Code
                && a.PostalCode.City.Name == address.PostalCode.City.Name
                && a.PostalCode.City.State.Name == address.PostalCode.City.State.Name)
                .SingleOrDefault();

            return result == null ? 0 : result.Id;
        }
    }
}