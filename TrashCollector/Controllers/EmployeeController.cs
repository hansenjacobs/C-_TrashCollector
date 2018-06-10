using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Data.Entity;

namespace TrashCollector.Controllers
{
    [Authorize(Roles =RoleName.Employee)]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Employee/Create
        public ActionResult Create()
        {
            return RedirectToAction("RegisterEmployee", "Account");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            var employee = _context.Employees.Include(e => e.ServicePostalCode).Single(e => e.UserId == id);
            var viewModel = new EmployeeViewModel()
            {
                NameFirst = employee.NameFirst,
                NameLast = employee.NameLast,
                UserId = employee.UserId,
                ServicePostalCodeForm = employee.ServicePostalCode.Code
            };
            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, EmployeeViewModel employee)
        {
            var employeeInDb = _context.Employees.Single(e => e.UserId == employee.UserId);
            employeeInDb.NameFirst = employee.NameFirst;
            employeeInDb.NameLast = employee.NameLast;
            employeeInDb.ServicePostalCodeId = PostalCode.GetPostalCodeId(_context, employee.ServicePostalCodeForm);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.ServicePostalCode)
                .ToList();
            return View(employees);
        }
    }
}
