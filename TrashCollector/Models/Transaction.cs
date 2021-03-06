﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
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

        public static void AddTransaction (ApplicationDbContext _context, string userAccountId, string description, double amount, string currentUserId)
        {
            var transaction = new Transaction()
            {
                UserAccountId = userAccountId,
                TransactionDateTime = DateTime.Now,
                Description = description,
                Amount = amount,
                EnteredById = currentUserId,
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

        }

    }
}