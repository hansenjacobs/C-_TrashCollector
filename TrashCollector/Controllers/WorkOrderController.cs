using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace TrashCollector.Controllers
{
    
    public class WorkOrderController : Controller
    {
        private ApplicationDbContext _context;

        public WorkOrderController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: WorkOrder
        [Authorize(Roles = RoleName.Employee)]
        public ActionResult Index()
        {
            var workOrders = _context.WorkOrders
                .Include(w => w.ServiceAddress.PostalCode.City.State)
                .Include(w => w.Status)
                .Include(w => w.Type)
                .Include(w => w.Customer);
            return View(workOrders);
        }

        [Authorize(Roles = RoleName.Employee)]
        public ActionResult EmployeeDashboard()
        {
            int? userServicePostalCode = Employee.GetEmployeeById(_context, User.Identity.GetUserId()).ServicePostalCodeId;

            List<WorkOrder> workOrders;

            if (userServicePostalCode != null && userServicePostalCode > 0)
            {
                workOrders = _context.WorkOrders
                .Include(w => w.ServiceAddress.PostalCode.City.State)
                .Include(w => w.Status)
                .Include(w => w.Type)
                .Include(w => w.Customer)
                .Where(w => w.ServiceAddress.PostalCodeId == userServicePostalCode
                && (w.ScheduledDate == DateTime.Today
                || w.ScheduledDate < DateTime.Today
                && (w.Status.IsOpen == true
                || w.CompletionDateTime.Value.Date == DateTime.Today)))
                .ToList();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            return View(workOrders);
        }

        // GET: WorkOrder/Details/5
        public ActionResult Details(int id)
        {
            var workOrder = _context.WorkOrders
                .Include(w => w.ServiceAddress.PostalCode.City.State)
                .Include(w => w.Status)
                .Include(w => w.Type)
                .Include(w => w.CompletedBy)
                .Include(w => w.Customer)
                .SingleOrDefault(w => w.Id == id);
            return View(workOrder);
        }

        [Authorize(Roles = RoleName.Employee)]
        public ActionResult CompleteWorkOrder(int id)
        {
            var workOrder = _context.WorkOrders.Include(w => w.Type).Single(w => w.Id == id);
            // Create Transaction
            var transaction = new Transaction()
            {
                Amount = 4,
                Description = workOrder.Type.Name + "Pickup",
                EnteredById = User.Identity.GetUserId(),
                TransactionDateTime = DateTime.Now,
                UserAccountId = workOrder.CustomerUserId
            };

            _context.Transactions.Add(transaction);
            
            workOrder.StatusId = WorkOrderStatus.Completed;
            workOrder.CompletedById = User.Identity.GetUserId();
            workOrder.CompletionDateTime = DateTime.Now;

            _context.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: WorkOrder/Create
        [Authorize(Roles =RoleName.Customer + ", " +RoleName.Employee)]
        public ActionResult Create()
        {
            WorkOrderCreateViewModel viewModel;

            if (User.IsInRole(RoleName.Employee))
            {
                viewModel = new WorkOrderCreateViewModel()
                {
                    Customers = _context.Customers.OrderBy(c => c.NameLast).ThenBy(c => c.NameFirst).ToList(),
                    Statuses = _context.WorkOrderStatuses.ToList(),
                    StatusId = WorkOrderStatus.Confirmed
                };
            }
            else
            {
                viewModel = new WorkOrderCreateViewModel()
                {
                    CustomerUserId = User.Identity.GetUserId(),
                    StatusId = WorkOrderStatus.Confirmed
                };
            }
            

            return View(viewModel);
        }

        // POST: WorkOrder/Create
        [Authorize(Roles = RoleName.Customer + "," +RoleName.Employee)]
        [HttpPost]
        public ActionResult Create(WorkOrderCreateViewModel viewModel)
        {
            if (User.IsInRole(RoleName.Customer))
            {
                viewModel.CustomerUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                if (User.IsInRole(RoleName.Employee))
                {
                    viewModel.Customers = _context.Customers.OrderBy(c => c.NameLast).ThenBy(c => c.NameFirst).ToList();
                    viewModel.Statuses = _context.WorkOrderStatuses.ToList();
                }

                return View(viewModel);
            }

            var newWorkOrder = new WorkOrder()
            {
                SubmittedDateTime = DateTime.Now,
                CustomerUserId = viewModel.CustomerUserId,
                ScheduledDate = viewModel.ScheduledDate == null ? DateTime.Today.AddDays(1) : (DateTime) viewModel.ScheduledDate,
                ServiceAddressId = _context.Customers.Single(c => c.UserId == viewModel.CustomerUserId).AddressId,
                StatusId = viewModel.StatusId,
                CompletedById = viewModel.StatusId == WorkOrderStatus.Completed ? User.Identity.GetUserId() : null,
                CompletionDateTime = viewModel.StatusId == WorkOrderStatus.Completed ? (DateTime?)DateTime.Now : null,
                TypeId = WorkOrderType.OneTime
            };

            _context.WorkOrders.Add(newWorkOrder);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = newWorkOrder.Id });
        }

        // GET: WorkOrder/Edit/5
        [Authorize(Roles = RoleName.Employee)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        [Authorize(Roles = RoleName.Employee)]
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

        // GET: WorkOrder/Delete/5
        [Authorize(Roles = RoleName.Employee)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkOrder/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.Employee)]
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
