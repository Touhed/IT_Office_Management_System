using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ITOfficeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;
        public EmployeeController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") == "2" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddEmployee()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                if (ModelState.IsValid)
                {
                    Employee e = new Employee
                    {
                        EmployeeId = model.EmployeeId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        Contact = model.Contact,
                        Address = model.Address,
                        DOB = model.DOB,
                        Gender = model.Gender,
                        JoiningDate = model.JoiningDate,
                        Designation = model.Designation,
                        BasicSalary = model.BasicSalary
                    };
                    db.Employee.Add(e);
                    db.SaveChanges();
                    ViewBag.Success = "Employee Account Created Successfully.";
                    ModelState.Clear();
                }
                return View();
                //return RedirectToAction("EmployeeList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult EmployeeList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var a = db.Employee.AsNoTracking().ToList();
                var i = new List<EmployeeVM>();
                foreach (var item in a)
                {
                    EmployeeVM ev = new EmployeeVM()
                    {
                        EmployeeId = item.EmployeeId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Password = item.Password,
                        Contact = item.Contact,
                        Address = item.Address,
                        DOB = item.DOB,
                        Gender = item.Gender,
                        JoiningDate = item.JoiningDate,
                        Designation = item.Designation,
                        BasicSalary = item.BasicSalary
                    };
                    i.Add(ev);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EmployeeDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().Where(s => s.EmployeeId == id).FirstOrDefault();
                EmployeeVM ev = new EmployeeVM()
                {
                    EmployeeId = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Contact = item.Contact,
                    Address = item.Address,
                    DOB = item.DOB,
                    Gender = item.Gender,
                    JoiningDate = item.JoiningDate,
                    Designation = item.Designation,
                    BasicSalary = item.BasicSalary
                };
                return View(ev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateEmployee(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().Where(s => s.EmployeeId == id).FirstOrDefault();
                EmployeeVM ev = new EmployeeVM()
                {
                    EmployeeId = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Contact = item.Contact,
                    Address = item.Address,
                    DOB = item.DOB,
                    Gender = item.Gender,
                    JoiningDate = item.JoiningDate,
                    Designation = item.Designation,
                    BasicSalary = item.BasicSalary
                };
                return View(ev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Employee e = new Employee()
                {
                    EmployeeId = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Contact = item.Contact,
                    Address = item.Address,
                    DOB = item.DOB,
                    Gender = item.Gender,
                    JoiningDate = item.JoiningDate,
                    Designation = item.Designation,
                    BasicSalary = item.BasicSalary
                };
                db.Employee.Update(e);
                db.SaveChanges();
                ViewBag.Success = "Employee Account Updated Successfully.";
                return RedirectToAction("EmployeeList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteEmployee(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().Where(s => s.EmployeeId == id).FirstOrDefault();
                EmployeeVM ev = new EmployeeVM()
                {
                    EmployeeId = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Contact = item.Contact,
                    Address = item.Address,
                    DOB = item.DOB,
                    Gender = item.Gender,
                    JoiningDate = item.JoiningDate,
                    Designation = item.Designation,
                    BasicSalary = item.BasicSalary
                };
                return View(ev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Employee.Where(s => s.EmployeeId == item.EmployeeId).FirstOrDefault();
                db.Employee.Remove(i);
                db.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Search(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().Where(s => s.EmployeeId == id).FirstOrDefault();
                EmployeeVM ev = new EmployeeVM()
                {
                    EmployeeId = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Contact = item.Contact,
                    Address = item.Address,
                    DOB = item.DOB,
                    Gender = item.Gender,
                    JoiningDate = item.JoiningDate,
                    Designation = item.Designation,
                    BasicSalary = item.BasicSalary
                };
                return View(ev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}