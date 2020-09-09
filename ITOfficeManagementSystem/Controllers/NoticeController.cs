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
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext db;
        public NoticeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult AddNotice()
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
        public IActionResult AddNotice(Notice a)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Notice ur = new Notice()
                {
                    NoticeId = a.NoticeId,
                    Title = a.Title,
                    Details = a.Details
                };
                db.Notice.Add(ur);
                db.SaveChanges();
                ViewBag.Success = "Notice Added Successfully.";
                ModelState.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult NoticeList()
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Notice.AsNoTracking().ToList();
                var i = new List<Notice>();
                foreach (var item in item1)
                {
                    Notice urv = new Notice()
                    {
                        NoticeId = item.NoticeId,
                        Title = item.Title,
                        Details = item.Details,
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

        public IActionResult NoticeDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != null && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Notice.AsNoTracking().Where(s => s.NoticeId == id).FirstOrDefault();
                Notice urv = new Notice()
                {
                    NoticeId = item.NoticeId,
                    Title = item.Title,
                    Details = item.Details,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult UpdateNotice(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Notice.AsNoTracking().Where(a => a.NoticeId == id).FirstOrDefault();
                Notice urv = new Notice()
                {
                    NoticeId = item.NoticeId,
                    Title = item.Title,
                    Details = item.Details,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateNotice(Notice item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                Notice urv = new Notice()
                {
                    NoticeId = item.NoticeId,
                    Title = item.Title,
                    Details = item.Details,
                };
                db.Notice.Update(urv);
                db.SaveChanges();
                return RedirectToAction("NoticeList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteNotice(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Notice.AsNoTracking().Where(s => s.NoticeId == id).FirstOrDefault();
                Notice urv = new Notice()
                {
                    NoticeId = item.NoticeId,
                    Title = item.Title,
                    Details = item.Details,
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteNotice(Notice item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Notice.AsNoTracking().Where(a => a.NoticeId == item.NoticeId).FirstOrDefault();
                db.Notice.Remove(i);
                db.SaveChanges();
                return RedirectToAction("NoticeList");
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
                var item = db.Notice.AsNoTracking().Where(s => s.NoticeId == id).FirstOrDefault();
                Notice urv = new Notice()
                {
                    NoticeId = item.NoticeId,
                    Title = item.Title,
                    Details = item.Details,
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