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

        public string NameFirstLast
        {
            get { return NameFirst + " " + NameLast; }
        }

        public string NameLastFirst
        {
            get { return NameLast + ", " + NameFirst; }
        }

        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int? WeeklyPickupDayId { get; set; }
        public WeekDay WeeklyPickupDay { get; set; }

        public IEnumerable<Transaction> GetTransactions (ApplicationDbContext _context)
        {
            return _context.Transactions.Where(t => t.UserAccountId == UserId).OrderBy(t => t.TransactionDateTime).ToList();
        }

        public void AddNewTransaction(ApplicationDbContext _context, string description, double amount, string userId)
        {
            Transaction.AddTransaction(_context, UserId, description, amount, userId);
        }

        public double GetCurrentBalance (ApplicationDbContext _context)
        {
            var transactions = _context.Transactions.Where(t => t.UserAccountId == UserId).ToList();
            var balance = 0.0;
            foreach(var transaction in transactions)
            {
                balance += transaction.Amount;
            }

            return balance;
        }

        public static double GetCurrentBalance(ApplicationDbContext _context, string userId)
        {
            var transactions = _context.Transactions.Where(t => t.UserAccountId == userId).ToList();
            var balance = 0.0;
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }

            return balance;
        }

        
    }
}