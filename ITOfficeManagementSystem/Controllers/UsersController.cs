using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITOfficeManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;
        public UsersController(ApplicationDbContext context)
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

        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.UserRole.AsNoTracking().ToList();
                ViewBag.UserType = new SelectList(item, "UserRoleId", "UserType");

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Register(Users model)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                if (ModelState.IsValid)
                {
                    Users u = new Users
                    {
                        UserType = model.UserType,
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = model.Password,
                        ConfirmPassword = model.ConfirmPassword,
                        UserRoleId = model.UserRoleId
                    };
                    db.Users.Add(u);
                    db.SaveChanges();
                    ViewBag.Success = "User Account Created Successfully.";
                    ModelState.Clear();
                }
                return View();
                //return RedirectToAction("UserList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UserList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var a = db.Users.AsNoTracking().ToList();
                var i = new List<UserVM>();
                foreach (var item in a)
                {
                    UserVM uv = new UserVM()
                    {
                        UserId = item.UserId,
                        UserType = item.UserType,
                        UserName = item.UserName,
                        Email = item.Email,
                        Password = item.Password,
                        ConfirmPassword = item.ConfirmPassword
                    };
                    i.Add(uv);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UserDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Users.AsNoTracking().Where(s => s.UserId == id).FirstOrDefault();
                UserVM uv = new UserVM()
                {
                    UserId = item.UserId,
                    UserType = item.UserType,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    UserRoleId = item.UserRoleId
                };
                return View(uv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult UpdateUser(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Users.AsNoTracking().Where(s => s.UserId == id).FirstOrDefault();
                UserVM uv = new UserVM()
                {
                    UserId = item.UserId,
                    UserType = item.UserType,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    UserRoleId = item.UserRoleId
                };
                return View(uv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
                
        [HttpPost]
        public IActionResult UpdateUser(UserVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Users u = new Users()
                {
                    UserId = item.UserId,
                    UserType = item.UserType,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    UserRoleId = item.UserRoleId
                };
                db.Users.Update(u);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteUser(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Users.AsNoTracking().Where(s => s.UserId == id).FirstOrDefault();
                UserVM uv = new UserVM()
                {
                    UserId = item.UserId,
                    UserType = item.UserType,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    UserRoleId = item.UserRoleId
                };
                return View(uv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteUser(UserVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Users.Where(s => s.UserId == item.UserId).FirstOrDefault();
                db.Users.Remove(i);
                db.SaveChanges();
                return RedirectToAction("UserList");
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
                var item = db.Users.AsNoTracking().Where(s => s.UserId == id).FirstOrDefault();
                UserVM uv = new UserVM()
                {
                    UserId = item.UserId,
                    UserType = item.UserType,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    UserRoleId = item.UserRoleId
                };
                return View(uv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(UserVM item)
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            Users u = new Users()
            {
                Email = item.Email
            };
            db.Users.Update(u);
            db.SaveChanges();
            return RedirectToAction("Login", "Users");
        }
    }
}