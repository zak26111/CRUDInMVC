using CRUDInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDInMVC.Controllers
{
    public class EmployeeController :  Controller
    {
            private readonly EmployeeDbContext _context;

            public EmployeeController()
            {
                _context = new EmployeeDbContext();
            }

            protected override void Dispose(bool disposing)
            {
                _context.Dispose();
            }

            //GET: Employee
            public ActionResult Index()
            {
                var employeeList = _context.Employees.ToList();
                return View(employeeList);
            }

            public ActionResult Create()
            {
                var employee = new Employee();
                return View(employee);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Employee employee)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Edit(int id)
            {
                var employeeFromDb = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employeeFromDb == null)
                    return HttpNotFound();
                return View(employeeFromDb);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Employee employee)
            {
                var employeeFromDb = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                employeeFromDb.Name= employee.Name;
                employeeFromDb.City= employee.City;
                employeeFromDb.Age= employee.Age;
                employeeFromDb.EmailId= employee.EmailId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Details(int id)
            {
                var employeeFromDb = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employeeFromDb == null)
                    return HttpNotFound();
                return View(employeeFromDb);
            }

            public ActionResult Delete(int id)
            {
                var employeeFromDb = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employeeFromDb == null)
                    return HttpNotFound();
                return View(employeeFromDb);
            }

            public ActionResult FinalDelete(int id)
            {
                var employeeFromDb = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employeeFromDb == null)
                    return HttpNotFound();
                _context.Employees.Remove(employeeFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }