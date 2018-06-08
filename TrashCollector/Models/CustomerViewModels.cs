using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class CustomerIndexViewModels
    {
        public ApplicationUser Customer { get; set; }
        public WorkOrder NextWorkOrder { get; set; }
    }

    public class CustomerProfileViewModel
    {
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string AddressForm { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CityForm { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateIdForm { get; set; }

        public IEnumerable<State> StateList { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 digits")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Zip code can only contain numerical digits.")]
        [Display(Name = "Postal Code")]
        public string PostalCodeForm { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required]
        [Display(Name = "Weekly Service Day")]
        public int WeeklyPickupDayId { get; set; }

        public IEnumerable<WeekDay> DaysOfOperation { get; set; }
    }
}