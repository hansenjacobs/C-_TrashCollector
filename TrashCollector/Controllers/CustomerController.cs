using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel()
            {
                Customer = _context.AspNetUsers.SingleOrDefault(a => a.UserName == User.Identity.Name)
            };

            viewModel.NextWorkOrder = _context.WorkOrders.OrderBy(w => w.ScheduledDate).FirstOrDefault(w => w.RequestedById == viewModel.Customer.Id);
            return View(viewModel);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
