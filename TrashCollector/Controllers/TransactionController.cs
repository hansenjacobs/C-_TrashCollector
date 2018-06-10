using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace TrashCollector.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext _context;

        public TransactionController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = RoleName.Customer)]
        // GET: Transaction
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new CustomerTransactionViewModel()
            {
                Customer = _context.Customers.Single(c => c.UserId == userId),
                Transactions = _context.Transactions
                    .Where(t => t.UserAccountId == userId)
                    .OrderByDescending(t => t.TransactionDateTime).ToList(),
                Balance = Customer.GetCurrentBalance(_context, userId)
            };
            return View(viewModel);
        }
    }
}