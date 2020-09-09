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
using Microsoft.EntityFrameworkCore.Internal;

namespace ITOfficeManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext db;
        public AttendanceController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Attendance()
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
        public IActionResult Attendance(AttendanceVM model)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Employee.Where(s => s.Email == model.Email && s.Password == model.Password).FirstOrDefault();
                if (i != null)
                {
                    HttpContext.Session.SetString("Employee", i.EmployeeId.ToString());
                    var employeeid = HttpContext.Session.GetString("Employee");
                    var item = db.Attendance.AsNoTracking().Where(a => a.EmployeeId == Convert.ToInt32(employeeid)).LastOrDefault();

                    if (ModelState.IsValid)
                    {
                        if (item != null)
                        {
                            if (item.LoginStatus == true)
                            {
                                item.LoginStatus = false;
                                item.LogoutTime = DateTime.Now;
                                item.LoginDuration = (item.LogoutTime - item.LoginTime).TotalHours;

                                db.Attendance.Update(item);
                                db.SaveChanges();
                                HttpContext.Session.Clear();

                                ViewBag.Logout = "Logged Out!";
                                ModelState.Clear();
                                return View();
                            }
                            else
                            {
                                var ei = Convert.ToInt32(i.EmployeeId);
                                Attendance a = new Attendance
                                {
                                    AttendanceId = model.AttendanceId,
                                    LoginStatus = true,
                                    Date = DateTime.Now,
                                    LoginTime = DateTime.Now,
                                    EmployeeId = ei
                                };
                                db.Attendance.Add(a);
                                db.SaveChanges();
                                ViewBag.Success = "Logged in!";
                                ModelState.Clear();
                                return View();
                            }
                            ///return RedirectToAction("AttendanceLogout");
                        }
                        else
                        {
                            var ei = Convert.ToInt32(i.EmployeeId);
                            Attendance a = new Attendance
                            {
                                AttendanceId = model.AttendanceId,
                                LoginStatus = true,
                                Date = DateTime.Now,
                                LoginTime = DateTime.Now,
                                EmployeeId = ei
                            };
                            db.Attendance.Add(a);
                            db.SaveChanges();
                            ViewBag.Success = "Logged in!";
                            ModelState.Clear();
                            return View();
                        }
                        //return RedirectToAction("AttendanceLogout");
                    }
                    return View();
                }
                else
                {
                    ViewBag.Error = "Username/Password is Incorrect.";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AttendanceLogout()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Attendance");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AttendanceList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var e = db.Employee.AsNoTracking().ToList();
                var a = db.Attendance.AsNoTracking().ToList();
                var i = new List<AttendanceVM>();
                var Result = from at in a
                             group at by at.EmployeeId into c
                             select new
                             {
                                 Employeeid = c.Key,
                                 TotalTime = c.Sum(s => s.LoginDuration)
                             };

                var query = (from employee in e
                             join attendance in a on employee.EmployeeId equals attendance.EmployeeId
                             join at in Result on attendance.EmployeeId equals at.Employeeid
                             select new
                             {
                                 Employeeid = employee.EmployeeId,
                                 Firstname = employee.FirstName,
                                 Lastname = employee.LastName,
                                 email = employee.Email,
                                 Attendanceid = attendance.AttendanceId,
                                 date = attendance.Date,
                                 Login_Time = attendance.LoginTime,
                                 Logout_Time = attendance.LogoutTime,
                                 Login_Status = attendance.LoginStatus,
                                 Login_Duration = attendance.LoginDuration,
                                 at.TotalTime
                             }).ToList();
                foreach (var item in query)
                {
                    AttendanceVM sa = new AttendanceVM();
                    {
                        sa.AttendanceId = item.Attendanceid;
                        sa.EmployeeId = item.Employeeid;
                        sa.FirstName = item.Firstname;
                        sa.LastName = item.Lastname;
                        sa.Email = item.email;
                        sa.Date = item.date;
                        sa.LoginTime = item.Login_Time;
                        sa.LogoutTime = item.Logout_Time;
                        sa.LoginStatus = item.Login_Status;
                        sa.LoginDuration = item.Login_Duration;
                        sa.TotalDuration = item.TotalTime;
                    }
                    //i = i.GroupBy(x => x.EmployeeId).Select(x => x.Last()).ToList();
                    i.Add(sa);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ScriptGenarate()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" ||
                HttpContext.Session.GetString("UserRole") == "2" &&
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var e = db.Employee.AsNoTracking().ToList();
                var a = db.Attendance.AsNoTracking().ToList();
                var i = new List<AttendanceVM>();
                var Result = from at in a
                             group at by at.EmployeeId into c
                             select new
                             {
                                 Employeeid = c.Key,
                                 TotalTime = c.Sum(s => s.LoginDuration)
                             };

                var query = (from employee in e
                             join attendance in a on employee.EmployeeId equals attendance.EmployeeId
                             join at in Result on attendance.EmployeeId equals at.Employeeid
                             select new
                             {
                                 Employeeid = employee.EmployeeId,
                                 Firstname = employee.FirstName,
                                 Lastname = employee.LastName,
                                 email = employee.Email,
                                 Attendanceid = attendance.AttendanceId,
                                 date = attendance.Date,
                                 Login_Time = attendance.LoginTime,
                                 Logout_Time = attendance.LogoutTime,
                                 Login_Status = attendance.LoginStatus,
                                 Login_Duration = attendance.LoginDuration,
                                 at.TotalTime
                             }).ToList();

                foreach (var item in query)
                {
                    AttendanceVM sa = new AttendanceVM();
                    {
                        sa.AttendanceId = item.Attendanceid;
                        sa.EmployeeId = item.Employeeid;
                        sa.FirstName = item.Firstname;
                        sa.LastName = item.Lastname;
                        sa.Email = item.email;
                        sa.Date = item.date;
                        sa.LoginTime = item.Login_Time;
                        sa.LogoutTime = item.Logout_Time;
                        sa.LoginStatus = item.Login_Status;
                        sa.LoginDuration = item.Login_Duration;
                        sa.TotalDuration = item.TotalTime;
                    }
                    //i = i.GroupBy(x => x.EmployeeId).Select(x => x.Last()).ToList();
                    i.Add(sa);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AttendanceDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var u = db.Employee.Where(q => q.EmployeeId == id).FirstOrDefault();
                var a = db.Attendance.ToList();
                var Result = from at in a
                             group at by at.EmployeeId into c
                             select new
                             {
                                 Employeeid = c.Key,
                                 TotalTime = c.Sum(s => s.LoginDuration)
                             };
                var query = (from attendance in db.Attendance
                             join employee in db.Employee on attendance.EmployeeId equals employee.EmployeeId
                             join at in Result on attendance.EmployeeId equals at.Employeeid
                             where attendance.AttendanceId == id
                             select new
                             {
                                 Employeeid = employee.EmployeeId,
                                 Firstname = employee.FirstName,
                                 Lastname = employee.LastName,
                                 email = employee.Email,
                                 Attendanceid = attendance.AttendanceId,
                                 date = attendance.Date,
                                 Login_Time = attendance.LoginTime,
                                 Logout_Time = attendance.LogoutTime,
                                 Login_Status = attendance.LoginStatus,
                                 Login_Duration = attendance.LoginDuration,
                                 at.TotalTime
                             });
                AttendanceVM avm = new AttendanceVM();
                foreach (var item in query)
                {
                    avm.AttendanceId = item.Attendanceid;
                    avm.EmployeeId = item.Employeeid;
                    avm.FirstName = item.Firstname;
                    avm.LastName = item.Lastname;
                    avm.Email = item.email;
                    avm.Date = item.date;
                    avm.LoginTime = item.Login_Time;
                    avm.LogoutTime = item.Logout_Time;
                    avm.LoginStatus = item.Login_Status;
                    avm.LoginDuration = item.Login_Duration;
                    avm.TotalDuration = item.TotalTime;
                }
                return View(avm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Search()
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

        public IActionResult DeleteAttendance(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var u = db.Employee.Where(q => q.EmployeeId == id).ToList();
                var a = db.Attendance.ToList();
                var Result = from at in a
                             group at by at.EmployeeId into c
                             select new
                             {
                                 Employeeid = c.Key,
                                 TotalTime = c.Sum(s => s.LoginDuration)
                             };
                var query = (from employee in db.Employee
                             from attendance in db.Attendance
                             join at in Result on attendance.EmployeeId equals at.Employeeid
                             select new
                             {
                                 Employeeid = employee.EmployeeId,
                                 Firstname = employee.FirstName,
                                 Lastname = employee.LastName,
                                 email = employee.Email,
                                 Attendanceid = attendance.AttendanceId,
                                 date = attendance.Date,
                                 Login_Time = attendance.LoginTime,
                                 Logout_Time = attendance.LogoutTime,
                                 Login_Status = attendance.LoginStatus,
                                 Login_Duration = attendance.LoginDuration,
                                 at.TotalTime
                             }).FirstOrDefault();

                AttendanceVM avm = new AttendanceVM();
                {
                    avm.AttendanceId = query.Attendanceid;
                    avm.EmployeeId = query.Employeeid;
                    avm.FirstName = query.Firstname;
                    avm.LastName = query.Lastname;
                    avm.Email = query.email;
                    avm.Date = query.date;
                    avm.LoginTime = query.Login_Time;
                    avm.LogoutTime = query.Logout_Time;
                    avm.LoginStatus = query.Login_Status;
                    avm.LoginDuration = query.Login_Duration;
                    avm.TotalDuration = query.TotalTime;
                }
                return View(avm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteAttendance(AttendanceVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.Attendance.Where(s => s.AttendanceId == item.AttendanceId).FirstOrDefault();
                db.Attendance.Remove(i);
                db.SaveChanges();
                return RedirectToAction("AttendanceList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}