using Collectr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collectr.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;

        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index(string name)
        {
            var user = context.Employees.Where(u => u.EmailAddress == name).Include(m => m.ApplicationUser).Single();
            var customers = context.Customers.Where(c => c.ZipCode == user.ZipCode).Where(c => c.WeeklyPickupDay == DateTime.Today.DayOfWeek).ToList();
            return View(customers);
        }


        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            var foundEmployee = context.Employees.Where(c => c.ApplicationId == id).Single();
            return View(foundEmployee);
        }

        public ActionResult CustomerDetails(string customerId)
        {
            var foundCustomer = context.Customers.Where(c => c.ApplicationId == customerId).Single();
            return View(foundCustomer);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string userId)
        {
            var employee = context.Employees.Where(u => u.ApplicationId == userId).Include(m => m.ApplicationUser).Single();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                Employee foundEmployee = context.Employees.Where(e => e.EmployeeId == employee.EmployeeId).Single();
                ApplicationUser foundUser = context.Users.Where(u => u.Id == foundEmployee.ApplicationId).Single();
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.ZipCode = employee.ZipCode;
                foundUser.Email = employee.EmailAddress;
                foundEmployee.EmailAddress = employee.EmailAddress;
                context.SaveChanges();

                return RedirectToAction("Index", new { userId = foundEmployee.ApplicationId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Collect(string customerId)
        {
            var foundEmployee = context.Employees.Where(e => e.EmailAddress == User.Identity.Name).Single();
            var foundCustomer = context.Customers.Where(c => c.ApplicationId == customerId).Single();

            foundCustomer.LatestPickedUp = true;
            foundCustomer.Balance += 40;
            foundCustomer.LastPickedUp = DateTime.Today;
            var nextPickupDay = DateTime.Today.AddDays(1);
            if (foundCustomer.ExtraPickupDay != null)
            {
                while (nextPickupDay.DayOfWeek != foundCustomer.WeeklyPickupDay && nextPickupDay != foundCustomer.ExtraPickupDay)
                {
                    nextPickupDay = nextPickupDay.AddDays(1);
                }
            }
            else
            {
                while (nextPickupDay.DayOfWeek != foundCustomer.WeeklyPickupDay)
                {
                    nextPickupDay = nextPickupDay.AddDays(1);
                }
            }

            if (foundCustomer.NoPickupStart != null && foundCustomer.NoPickupEnd != null && foundCustomer.NoPickupStart <= foundCustomer.NoPickupEnd)
            {
                if (nextPickupDay >= foundCustomer.NoPickupStart && nextPickupDay <= foundCustomer.NoPickupEnd)
                {
                    nextPickupDay = foundCustomer.NoPickupEnd.Value.AddDays(1);

                    if (foundCustomer.ExtraPickupDay != null)
                    {
                        while (nextPickupDay.DayOfWeek != foundCustomer.WeeklyPickupDay && nextPickupDay != foundCustomer.ExtraPickupDay)
                        {
                            nextPickupDay = nextPickupDay.AddDays(1);
                        }
                    }
                    else
                    {
                        while (nextPickupDay.DayOfWeek != foundCustomer.WeeklyPickupDay)
                        {
                            nextPickupDay = nextPickupDay.AddDays(1);
                        }
                    }
                }
            }
            
            foundCustomer.NextPickup = nextPickupDay;

            context.SaveChanges();

            return RedirectToAction("Index", new { name = foundEmployee.EmailAddress });
        }
    }
}
