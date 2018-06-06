using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Last Name")]
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

        public int? ServicePostalCodeId { get; set; }
        public PostalCode ServicePostalCode { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<WorkOrderType> WorkOrderTypes { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}