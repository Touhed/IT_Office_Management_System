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
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext db;
        public UserRoleController(ApplicationDbContext context)
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

        public IActionResult AddUserRole()
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
        public IActionResult AddUserRole(UserRoleVM a)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                UserRole ur = new UserRole()
                {
                    UserRoleId = a.UserRoleId,
                    UserType = a.UserType
                };
                db.UserRole.Add(ur);
                db.SaveChanges();
                ViewBag.Success = "User Type Created Successfully.";
                ModelState.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult UserRoleList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.UserRole.AsNoTracking().ToList();
                var i = new List<UserRoleVM>();
                foreach (var item in item1)
                {
                    UserRoleVM urv = new UserRoleVM()
                    {
                        UserRoleId = item.UserRoleId,
                        UserType = item.UserType
                    };
                    i.Add(urv);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UserRoleDetails(int id)
        { 
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.UserRole.AsNoTracking().Where(s => s.UserRoleId == id).FirstOrDefault();
                UserRoleVM urv = new UserRoleVM()
                {
                    UserRoleId = item.UserRoleId,
                    UserType = item.UserType,
                };
                return View(urv);
            }
            else
            {
               return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateUserRole(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.UserRole.AsNoTracking().Where(a => a.UserRoleId == id).FirstOrDefault();
                UserRoleVM urv = new UserRoleVM()
                {
                    UserRoleId = item.UserRoleId,
                    UserType = item.UserType,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult UpdateUserRole(UserRoleVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                UserRole ur = new UserRole()
                {
                    UserRoleId = item.UserRoleId,
                    UserType = item.UserType,
                };
                db.UserRole.Update(ur);
                db.SaveChanges();
                return RedirectToAction("UserRoleList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteUserRole(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.UserRole.AsNoTracking().Where(s => s.UserRoleId == id).FirstOrDefault();
                UserRoleVM urv = new UserRoleVM()
                {
                    UserRoleId = item.UserRoleId,
                    UserType = item.UserType,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteUserRole(UserRoleVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.UserRole.AsNoTracking().Where(a => a.UserRoleId == item.UserRoleId).FirstOrDefault();
                db.UserRole.Remove(i);
                db.SaveChanges();
                return RedirectToAction("UserRoleList");
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
                var item = db.UserRole.AsNoTracking().Where(s => s.UserRoleId == id).FirstOrDefault();
                UserRoleVM urv = new UserRoleVM()
                {
                    UserRoleId = item.UserRoleId,
                    UserType = item.UserType,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}