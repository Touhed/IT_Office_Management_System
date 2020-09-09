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
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext db;
        public ClientController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") == "3" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddClient()
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

        [HttpPost]
        public IActionResult AddClient(Client model)
        {
            if (ModelState.IsValid)
            {
                Client c = new Client
                {
                    ClientId = model.ClientId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Contact = model.Contact,
                    Gender = model.Gender,
                    OrganizationName = model.OrganizationName,
                    EmployeeId = model.EmployeeId
                };
                db.Client.Add(c);
                db.SaveChanges();
                ViewBag.Success = "Client Account Created Successfully.";
                ModelState.Clear();
            }
            return View();
            //return RedirectToAction("ClientList");
        }

        public IActionResult ClientList()
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var a = db.Client.AsNoTracking().ToList();
                var i = new List<ClientVM>();
                foreach (var item in a)
                {
                    ClientVM cv = new ClientVM()
                    {
                        ClientId = item.ClientId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Contact = item.Contact,
                        Gender = item.Gender,
                        OrganizationName = item.OrganizationName,
                        EmployeeId = item.EmployeeId
                    };
                    i.Add(cv);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ClientDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Client.AsNoTracking().Where(s => s.ClientId == id).FirstOrDefault();
                ClientVM cv = new ClientVM()
                {
                    ClientId = item.ClientId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Contact = item.Contact,
                    Gender = item.Gender,
                    OrganizationName = item.OrganizationName,
                    EmployeeId = item.EmployeeId
                };
                return View(cv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateClient(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Client.AsNoTracking().Where(s => s.ClientId == id).FirstOrDefault();
                ClientVM cv = new ClientVM()
                {
                    ClientId = item.ClientId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Contact = item.Contact,
                    Gender = item.Gender,
                    OrganizationName = item.OrganizationName,
                    EmployeeId = item.EmployeeId
                };
                return View(cv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateClient(ClientVM item)
        {
            Client c = new Client()
            {
                ClientId = item.ClientId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                Contact = item.Contact,
                Gender = item.Gender,
                OrganizationName = item.OrganizationName,
                EmployeeId = item.EmployeeId
            };
            db.Client.Update(c);
            db.SaveChanges();
            ViewBag.Success = "Client Account Updated Successfully.";
            return RedirectToAction("ClientList");
        }

        public IActionResult DeleteClient(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Client.AsNoTracking().Where(s => s.ClientId == id).FirstOrDefault();
                ClientVM cv = new ClientVM()
                {
                    ClientId = item.ClientId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Contact = item.Contact,
                    Gender = item.Gender,
                    OrganizationName = item.OrganizationName,
                    EmployeeId = item.EmployeeId
                };
                return View(cv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteClient(ClientVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Client.Where(s => s.ClientId == item.ClientId).FirstOrDefault();
                db.Client.Remove(i);
                db.SaveChanges();
                return RedirectToAction("ClientList");
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
                var item = db.Client.AsNoTracking().Where(s => s.ClientId == id).FirstOrDefault();
                ClientVM cv = new ClientVM()
                {
                    ClientId = item.ClientId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Contact = item.Contact,
                    Gender = item.Gender,
                    OrganizationName = item.OrganizationName,
                    EmployeeId = item.EmployeeId
                };
                return View(cv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}