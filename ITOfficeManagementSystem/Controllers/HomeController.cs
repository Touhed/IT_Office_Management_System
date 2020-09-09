using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ITOfficeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserVM model)
        {
            var result = db.Users.Where(s => s.Email == model.Email && s.Password == model.Password).FirstOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName", result.UserName);
                HttpContext.Session.SetString("Email", result.Email);
                HttpContext.Session.SetString("UserRole", result.UserRoleId.ToString());
                
                if (result.UserRoleId == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (result.UserRoleId == 2)
                {
                    return RedirectToAction("Index", "Employee");
                }
                if (result.UserRoleId == 3)
                {
                    return RedirectToAction("Index", "Client");
                }
            }
            ViewBag.Login = "User Email or Password Invalid!";
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Users", "Expired");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ScriptsGenarate()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" ||
                HttpContext.Session.GetString("UserRole") == "2" &&
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
