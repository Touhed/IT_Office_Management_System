using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITOfficeManagementSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext db;
        public FeedbackController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult AddFeedback()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "3" &&
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Client.AsNoTracking().ToList();
                ViewBag.Clientid = new SelectList(item1, "ClientId", "ClientId");

                return View(new Feedback());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddFeedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                Feedback f = new Feedback()
                {
                    FeedbackId = model.FeedbackId,
                    Reliability = model.Reliability,
                    Design = model.Design,
                    EaseOfUse = model.EaseOfUse,
                    Security = model.Security,
                    AbilityToIntegrate = model.AbilityToIntegrate,
                    AbilityToCollaborate = model.AbilityToCollaborate,
                    Description = model.Description,
                    ClientId = model.ClientId
                };
                db.Feedback.Add(f);
                db.SaveChanges();
                ViewBag.Success = "Feedback Added Successfully.";
                ModelState.Clear();
            }
            return View();
        }
        public IActionResult FeedbackList()
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Feedback.AsNoTracking().ToList();
                var i = new List<Feedback>();
                foreach (var item in item1)
                {
                    Feedback urv = new Feedback()
                    {
                        FeedbackId = item.FeedbackId,
                        Reliability = item.Reliability,
                        Design = item.Design,
                        EaseOfUse = item.EaseOfUse,
                        Security = item.Security,
                        AbilityToIntegrate = item.AbilityToIntegrate,
                        AbilityToCollaborate = item.AbilityToCollaborate,
                        Description = item.Description,
                        ClientId = item.ClientId
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

        public IActionResult FeedbackDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Feedback.AsNoTracking().Where(s => s.FeedbackId == id).FirstOrDefault();
                Feedback urv = new Feedback()
                {
                    FeedbackId = item.FeedbackId,
                    Reliability = item.Reliability,
                    Design = item.Design,
                    EaseOfUse = item.EaseOfUse,
                    Security = item.Security,
                    AbilityToIntegrate = item.AbilityToIntegrate,
                    AbilityToCollaborate = item.AbilityToCollaborate,
                    Description = item.Description,
                    ClientId = item.ClientId
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult UpdateFeedback(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Client.AsNoTracking().ToList();
                ViewBag.Clientid = new SelectList(item1, "ClientId", "ClientId");
                
                var item = db.Feedback.AsNoTracking().Where(a => a.FeedbackId == id).FirstOrDefault();
                Feedback urv = new Feedback()
                {
                    FeedbackId = item.FeedbackId,
                    Reliability = item.Reliability,
                    Design = item.Design,
                    EaseOfUse = item.EaseOfUse,
                    Security = item.Security,
                    AbilityToIntegrate = item.AbilityToIntegrate,
                    AbilityToCollaborate = item.AbilityToCollaborate,
                    Description = item.Description,
                    ClientId = item.ClientId
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateFeedback(Feedback item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Feedback ur = new Feedback()
                {
                    FeedbackId = item.FeedbackId,
                    Reliability = item.Reliability,
                    Design = item.Design,
                    EaseOfUse = item.EaseOfUse,
                    Security = item.Security,
                    AbilityToIntegrate = item.AbilityToIntegrate,
                    AbilityToCollaborate = item.AbilityToCollaborate,
                    Description = item.Description,
                    ClientId = item.ClientId
                };
                db.Feedback.Update(ur);
                db.SaveChanges();
                return RedirectToAction("FeedbackList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteFeedback(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Feedback.AsNoTracking().Where(s => s.FeedbackId == id).FirstOrDefault();
                Feedback urv = new Feedback()
                {
                    FeedbackId = item.FeedbackId,
                    Reliability = item.Reliability,
                    Design = item.Design,
                    EaseOfUse = item.EaseOfUse,
                    Security = item.Security,
                    AbilityToIntegrate = item.AbilityToIntegrate,
                    AbilityToCollaborate = item.AbilityToCollaborate,
                    Description = item.Description,
                    ClientId = item.ClientId
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteFeedback(Feedback item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Feedback.AsNoTracking().Where(a => a.FeedbackId == item.FeedbackId).FirstOrDefault();
                db.Feedback.Remove(i);
                db.SaveChanges();
                return RedirectToAction("FeedbackList");
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
                var item = db.Feedback.AsNoTracking().Where(s => s.FeedbackId == id).FirstOrDefault();
                Feedback urv = new Feedback()
                {
                    FeedbackId = item.FeedbackId,
                    Reliability = item.Reliability,
                    Design = item.Design,
                    EaseOfUse = item.EaseOfUse,
                    Security = item.Security,
                    AbilityToIntegrate = item.AbilityToIntegrate,
                    AbilityToCollaborate = item.AbilityToCollaborate,
                    Description = item.Description,
                    ClientId = item.ClientId
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
