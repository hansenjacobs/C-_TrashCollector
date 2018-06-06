using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TrashCollector.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterCustomerViewModel
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [Display(Name ="Address")]
        public string AddressForm { get; set; }

        [Required]
        [Display(Name ="City")]
        public string CityForm { get; set; }

        [Required]
        [Display(Name ="State")]
        public int StateIdForm { get; set; }

        public IEnumerable<State> StateList { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 digits")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Zip code can only contain numerical digits.")]
        [Display(Name ="Postal Code")]
        public string PostalCodeForm { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required]
        [Display(Name = "Weekly Service Day")]
        public int WeeklyPickupDayId { get; set; }

        public IEnumerable<WeekDay> DaysOfOperation { get; set; }
    }

    public class RegisterEmployeeViewModel
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [Display(Name ="Address")]
        public string AddressForm { get; set; }

        [Required]
        [Display(Name ="City")]
        public string CityForm { get; set; }

        [Required]
        [Display(Name ="State")]
        public int StateIdForm { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 digits")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Zip code can only contain numerical digits.")]
        [Display(Name ="Postal Code")]
        public string PostalCodeForm { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Display(Name ="Service Postal Code")]
        public string ServicePostalCodeForm { get; set; }

        public int ServicePostalCodeId { get; set; }
        public PostalCode ServicePostalCode { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
