using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITOfficeManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        public AdminController(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IActionResult Index()
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

        public IActionResult AdminActivities()
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

        public IActionResult AddAdmin()
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
        public IActionResult AddAdmin(Admin model)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                if (ModelState.IsValid)
                {
                    Admin a = new Admin
                    {
                        AdminId = model.AdminId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Gender = model.Gender,
                        Email = model.Email,
                        Contact = model.Contact,
                        Address = model.Address
                    };
                    db.Admin.Add(a);
                    db.SaveChanges();
                    ViewBag.Success = "Admin Account Created Successfully.";
                    ModelState.Clear();
                }
                return View();
                //return RedirectToAction("AdminList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AdminList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var a = db.Admin.AsNoTracking().ToList();
                var i = new List<AdminVM>();
                foreach (var item in a)
                {
                    AdminVM av = new AdminVM()
                    {
                        AdminId = item.AdminId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Gender = item.Gender,
                        Email = item.Email,
                        Contact = item.Contact,
                        Address = item.Address
                    };
                    i.Add(av);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AdminDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Admin.AsNoTracking().Where(s => s.AdminId == id).FirstOrDefault();
                AdminVM av = new AdminVM()
                {
                    AdminId = item.AdminId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address
                };
                return View(av);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateAdmin(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Admin.AsNoTracking().Where(s => s.AdminId == id).FirstOrDefault();
                AdminVM av = new AdminVM()
                {
                    AdminId = item.AdminId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address
                };
                return View(av);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateAdmin(AdminVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Admin a = new Admin()
                {
                    AdminId = item.AdminId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address
                };
                db.Admin.Update(a);
                db.SaveChanges();
                ViewBag.Success = "Admin Account Updated Successfully.";
                return RedirectToAction("AdminList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteAdmin(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Admin.AsNoTracking().Where(s => s.AdminId == id).FirstOrDefault();
                AdminVM av = new AdminVM()
                {
                    AdminId = item.AdminId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address
                };
                return View(av);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteAdmin(AdminVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Admin.Where(s => s.AdminId == item.AdminId).FirstOrDefault();
                db.Admin.Remove(i);
                db.SaveChanges();
                return RedirectToAction("AdminList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Search(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Admin.AsNoTracking().Where(s => s.AdminId == id).FirstOrDefault();
                AdminVM av = new AdminVM()
                {
                    AdminId = item.AdminId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address
                };
                return View(av);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}