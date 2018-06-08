using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

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
            if(User.IsInRole(RoleName.Employee))
            {
                var customers = _context.Customers
                    .Include(c => c.Address.PostalCode.City.State)
                    .Include(c => c.WeeklyPickupDay)
                    .ToList();
                return View(customers);
            }

            return RedirectToAction("Edit", "Customer", new { id = User.Identity.GetUserId() });
        }


        // GET: Customer/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (!User.IsInRole(RoleName.Employee))
            {
                id = User.Identity.GetUserId();
            }

            var customerInDb = _context.Customers
                .Include(c => c.Address.PostalCode.City.State)
                .Include(c => c.WeeklyPickupDay)
                .Single(c => c.UserId == id);

            var viewModel = new CustomerProfileViewModel()
            {
                UserId = customerInDb.UserId,
                AddressForm = customerInDb.Address.AddressLine,
                CityForm = customerInDb.Address.PostalCode.City.Name,
                StateIdForm = customerInDb.Address.PostalCode.City.StateId,
                PostalCodeForm = customerInDb.Address.PostalCode.Code,
                NameFirst = customerInDb.NameFirst,
                NameLast = customerInDb.NameLast,
                Phone = customerInDb.Phone,
                WeeklyPickupDayId = customerInDb.WeeklyPickupDayId == null ? 0 : (int)customerInDb.WeeklyPickupDayId,
                DaysOfOperation = WeekDay.GetOperatingDays(_context),
                StateList = State.GetStates(_context)
            };

            return View(viewModel);
        }

        [Authorize]
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CustomerProfileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DaysOfOperation = WeekDay.GetOperatingDays(_context);
                viewModel.StateList = State.GetStates(_context);
                return View("Edit", viewModel);
            }

            if (!User.IsInRole(RoleName.Employee))
            {
                id = User.Identity.GetUserId();
            }

            var customerInDb = _context.Customers.Single(c => c.UserId == id);

            customerInDb.NameFirst = viewModel.NameFirst.ToUpper();
            customerInDb.NameLast = viewModel.NameLast.ToUpper();
            customerInDb.Phone = viewModel.Phone;
            customerInDb.WeeklyPickupDayId = viewModel.WeeklyPickupDayId;

            viewModel.AddressForm = viewModel.AddressForm.ToUpper();
            viewModel.CityForm = viewModel.CityForm.ToUpper();
            viewModel.PostalCodeForm = viewModel.PostalCodeForm.ToUpper();

            viewModel.Address = new Address()
            {
                AddressLine = viewModel.AddressForm,
                PostalCode = new PostalCode()
                {
                    Code = viewModel.PostalCodeForm,
                    City = new City()
                    {
                        Name = viewModel.CityForm,
                        State = new State() { Id = viewModel.StateIdForm, Name = State.GetStateNameById(_context, viewModel.StateIdForm) }
                    }
                }
            };
            viewModel.Address.Id = Address.GetAddressId(_context, viewModel.Address);
            viewModel.AddressId = viewModel.Address.Id;
            if(viewModel.AddressId == 0)
            {
                viewModel.Address = Address.AddAddress(_context, viewModel.Address);
                viewModel.AddressId = viewModel.Address.Id;
            }

            customerInDb.AddressId = viewModel.AddressId;

            _context.SaveChanges();

            TempData["ProfileUpdate"] = "success";
            return RedirectToAction("Index");

            
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
