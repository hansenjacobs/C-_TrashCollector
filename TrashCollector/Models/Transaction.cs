using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name ="User Account")]
        public string UserAccountId { get; set; }
        public ApplicationUser UserAccount { get; set; }

        public DateTime TransactionDateTime { get; set; }

        [Required]
        [StringLength(75)]
        public string Description { get; set; }

        public double Amount { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name ="Entered by")]
        public string EnteredById { get; set; }
        public ApplicationUser EnteredBy { get; set; }

    }
}