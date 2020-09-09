using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITOfficeManagementSystem.Controllers
{
    public class AssignTaskController : Controller
    {
        private readonly ApplicationDbContext db;
        public AssignTaskController(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IActionResult AddTask()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().ToList();
                ViewBag.Employeeid = new SelectList(item, "EmployeeId", "EmployeeId");

                return View(new AssignTask());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddTask(AssignTask a)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                AssignTask t = new AssignTask()
                {
                    TaskId = a.TaskId,
                    TaskTitle = a.TaskTitle,
                    Description = a.Description,
                    Date = DateTime.Now,
                    EmployeeId = a.EmployeeId

                };
                db.AssignTask.Add(t);
                db.SaveChanges();
                ViewBag.Success = "Task Assigned Successfully.";
                ModelState.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult TaskList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var list = db.AssignTask.AsNoTracking().ToList();
                var i = new List<AssignTaskVM>();

                foreach (var item in list)
                {
                    AssignTaskVM t = new AssignTaskVM()
                    {
                        TaskId = item.TaskId,
                        TaskTitle = item.TaskTitle,
                        Description = item.Description,
                        Date = item.Date,
                        EmployeeId = item.EmployeeId
                    };
                    i.Add(t);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult TaskDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.AssignTask.AsNoTracking().Where(s => s.TaskId == id).FirstOrDefault();
                AssignTaskVM t = new AssignTaskVM()
                {
                    TaskId = item.TaskId,
                    TaskTitle = item.TaskTitle,
                    Description = item.Description,
                    Date = item.Date,
                    EmployeeId = item.EmployeeId
                };
                return View(t);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult UpdateTask(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Employee.AsNoTracking().ToList();
                ViewBag.Employeeid = new SelectList(item1, "EmployeeId", "EmployeeId");

                var item = db.AssignTask.AsNoTracking().Where(a => a.TaskId == id).FirstOrDefault();
                AssignTask t = new AssignTask()
                {
                    TaskId = item.TaskId,
                    TaskTitle = item.TaskTitle,
                    Description = item.Description,
                    Date = item.Date,
                    EmployeeId = item.EmployeeId
                };
                return View(t);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult UpdateTask(AssignTask item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                AssignTask t = new AssignTask()
                {
                    TaskId = item.TaskId,
                    TaskTitle = item.TaskTitle,
                    Description = item.Description,
                    Date = item.Date,
                    EmployeeId = item.EmployeeId
                };
                db.AssignTask.Update(t);
                db.SaveChanges();
                return RedirectToAction("TaskList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteTask(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.AssignTask.AsNoTracking().Where(s => s.TaskId == id).FirstOrDefault();
                AssignTaskVM t = new AssignTaskVM()
                {
                    TaskId = item.TaskId,
                    TaskTitle = item.TaskTitle,
                    Description = item.Description,
                    Date = item.Date,
                    EmployeeId = item.EmployeeId
                };
                return View(t);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteTask(AssignTaskVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.AssignTask.AsNoTracking().Where(a => a.TaskId == item.TaskId).FirstOrDefault();
                db.AssignTask.Remove(i);
                db.SaveChanges();
                return RedirectToAction("TaskList");
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
                var item = db.AssignTask.AsNoTracking().Where(s => s.TaskId == id).FirstOrDefault();
                AssignTask t = new AssignTask()
                {
                    TaskId = item.TaskId,
                    TaskTitle = item.TaskTitle,
                    Description = item.Description,
                    Date = item.Date,
                    EmployeeId = item.EmployeeId
                };
                return View(t);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}