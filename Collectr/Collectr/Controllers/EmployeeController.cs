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
        public ActionResult Index(string userId)
        {
            var user = context.Employees.Where(u => u.ApplicationId == userId).Include(m => m.ApplicationUser).Single();
            return View(user);
        }


        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
