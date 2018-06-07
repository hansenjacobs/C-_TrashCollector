using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Required]
        [StringLength(128)]
        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        public int? ServicePostalCodeId { get; set; }
        public PostalCode ServicePostalCode { get; set; }
    }
}