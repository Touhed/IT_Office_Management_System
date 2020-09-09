using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITOfficeManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext db;
        public EventController(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IActionResult AddEvent()
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
        public IActionResult AddEvent(Event a)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Event ur = new Event()
                {
                    EventId = a.EventId,
                    EventTitle = a.EventTitle,
                    EventDetails = a.EventDetails,

                };
                db.Event.Add(ur);
                db.SaveChanges();
                ViewBag.Success = "Event Created Successfully.";
                ModelState.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult EventList()
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Event.AsNoTracking().ToList();
                var i = new List<Event>();
                foreach (var item in item1)
                {
                    Event urv = new Event()
                    {
                        EventId = item.EventId,
                        EventTitle = item.EventTitle,
                        EventDetails = item.EventDetails,
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

        public IActionResult EventDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Event.AsNoTracking().Where(s => s.EventId == id).FirstOrDefault();
                Event urv = new Event()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle,
                    EventDetails = item.EventDetails,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult UpdateEvent(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Event.AsNoTracking().Where(a => a.EventId == id).FirstOrDefault();
                Event urv = new Event()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle,
                    EventDetails = item.EventDetails,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateEvent(Event item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Event ur = new Event()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle,
                    EventDetails = item.EventDetails,
                };
                db.Event.Update(ur);
                db.SaveChanges();
                return RedirectToAction("EventList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteEvent(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Event.AsNoTracking().Where(s => s.EventId == id).FirstOrDefault();
                Event urv = new Event()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle,
                    EventDetails = item.EventDetails,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteEvent(Event item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Event.AsNoTracking().Where(a => a.EventId == item.EventId).FirstOrDefault();
                db.Event.Remove(i);
                db.SaveChanges();
                return RedirectToAction("EventList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Search(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Event.AsNoTracking().Where(s => s.EventId == id).FirstOrDefault();
                Event urv = new Event()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle,
                    EventDetails = item.EventDetails,
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