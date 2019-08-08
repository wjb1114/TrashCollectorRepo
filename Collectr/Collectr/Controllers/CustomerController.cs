using Collectr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collectr.Controllers
{
    public class CustomerController : Controller
        
    {
        ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index(string userId)
        {
            var user = context.Customers.Where(u => u.ApplicationId == userId).Include(m => m.ApplicationUser).Single();
            return View(user);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(string userId)
        {
            var employee = context.Customers.Where(u => u.ApplicationId == userId).Include(m => m.ApplicationUser).Single();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                Customer foundCustomer = context.Customers.Where(c => c.CustomerId == customer.CustomerId).Single();
                ApplicationUser foundUser = context.Users.Where(u => u.Id == foundCustomer.ApplicationId).Single();
                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundUser.Email = customer.EmailAddress;
                foundCustomer.EmailAddress = customer.EmailAddress;
                foundCustomer.StreetAddress = customer.StreetAddress;
                foundCustomer.City = customer.City;
                foundCustomer.State = customer.State;
                foundCustomer.ZipCode = customer.ZipCode;
                foundCustomer.WeeklyPickupDay = customer.WeeklyPickupDay;
                foundCustomer.ExtraPickupDay = customer.ExtraPickupDay;
                foundCustomer.NoPickupStart = customer.NoPickupStart;
                foundCustomer.NoPickupEnd = customer.NoPickupEnd;


                DateTime nextPickup = DateTime.Today;
                while (nextPickup.DayOfWeek != foundCustomer.WeeklyPickupDay)
                {
                    nextPickup = nextPickup.AddDays(1);
                }

                foundCustomer.NextPickup = nextPickup;
                context.SaveChanges();

                return RedirectToAction("Index", new { userId = foundCustomer.ApplicationId });
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
