using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Required]
        [StringLength(128)]
        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int? WeeklyPickupDayId { get; set; }
        public WeekDay WeeklyPickupDay { get; set; }
    }
}