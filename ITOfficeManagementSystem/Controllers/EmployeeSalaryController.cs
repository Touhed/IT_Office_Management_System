using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITOfficeManagementSystem.Data;
using ITOfficeManagementSystem.Models;
using ITOfficeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ITOfficeManagementSystem.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly ApplicationDbContext db;
        public EmployeeSalaryController(ApplicationDbContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult AddSalary()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item = db.Employee.AsNoTracking().ToList();
                ViewBag.Employeeid = new SelectList(item, "EmployeeId", "EmployeeId");

                var item1 = db.Employee.AsNoTracking().ToList();
                ViewBag.BasicSalary = new SelectList(item1, "BasicSalary", "BasicSalary");

                var item2 = db.Attendance.AsNoTracking().ToList();
                ViewBag.Attendanceid = new SelectList(item2, "AttendanceId", "EmployeeId");

                return View(new EmployeeSalaryVM());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        [HttpPost]
        public IActionResult AddSalary(EmployeeSalaryVM model)
        {
            var item2 = db.EmployeeSalary.AsNoTracking().Where(a => a.SalaryId == model.SalaryId).FirstOrDefault();
            Attendance item = new Attendance();

            if (model.BasicSalary > 50000)
            {
                model.Tax = model.BasicSalary * 1 / 100;
            }
            else if (model.BasicSalary > 30000)
            {
                model.Tax = model.BasicSalary * .5 / 100;
            }
            else
            {
                model.Tax = 0;
            }
            // basic salary / number of working days in month * actual work
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var perDaySalary = model.BasicSalary / days;
            var offdays = perDaySalary * 8;
            double hourPrice = perDaySalary / 24;
            model.HourPrice = hourPrice;
            //double hoursWorked = (double)minutesWorked / 60;
            //var totalHourPrice = (double)minutesWorked * (model.HourPrice);
            model.TotalHourPrice = model.LoginDuration * model.HourPrice;
            model.NetSalary = (model.BasicSalary + model.Benifits + model.TotalHourPrice) - model.Tax;
            model.PaymentStatus = Convert.ToInt32(model.NetSalary - model.Withdraw);

            if (ModelState.IsValid)
            {
                EmployeeSalary ur = new EmployeeSalary();
                ur.SalaryId = model.SalaryId;
                ur.BasicSalary = model.BasicSalary;
                ur.Tax = model.Tax;
                ur.Benifits = model.Benifits;
                ur.HourPrice = model.HourPrice;
                ur.TotalHourPrice = model.TotalHourPrice;
                ur.NetSalary = model.NetSalary;
                ur.Withdraw = model.Withdraw;
                ur.PaymentStatus = model.PaymentStatus;
                ur.EmployeeId = model.EmployeeId;
                ur.AttendanceId = model.AttendanceId;
                db.EmployeeSalary.Add(ur);
                db.SaveChanges();
            }
            ViewBag.Success = "Employee Salary Added Successfully.";
            ModelState.Clear();
            return View(model);
        }
        public IActionResult EmployeeSalaryList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var e = db.Employee.AsNoTracking().ToList();
                var a = db.Attendance.AsNoTracking().ToList();
                var emps = db.EmployeeSalary.AsNoTracking().ToList();
                var i = new List<EmployeeSalaryVM>();

                var query = (from es in emps
                             join employee in e on es.EmployeeId equals employee.EmployeeId
                             join at in a on es.AttendanceId equals at.AttendanceId
                             select new
                             {
                                 employeeid = employee.EmployeeId,
                                 firstname = employee.FirstName,
                                 lastname = employee.LastName,
                                 attendanceid = at.AttendanceId,
                                 loginduration = at.LoginDuration,
                                 salaryid = es.SalaryId,
                                 basicsalary = es.BasicSalary,
                                 tax = es.Tax / 100,
                                 benifits = es.Benifits,
                                 hourprice = es.HourPrice,
                                 totalhourPrice = at.LoginDuration * es.HourPrice,
                                 withdraw = es.Withdraw,
                                 netsalary = ((es.BasicSalary + es.Benifits) - es.Tax),
                                 paymentstatus = (es.NetSalary - es.Withdraw)
                             });

                foreach (var item in query)
                {
                    EmployeeSalaryVM es = new EmployeeSalaryVM();
                    {
                        es.EmployeeId = item.employeeid;
                        es.FirstName = item.firstname;
                        es.LastName = item.lastname;
                        es.AttendanceId = item.attendanceid;
                        es.LoginDuration = item.loginduration;
                        es.SalaryId = item.salaryid;
                        es.BasicSalary = item.basicsalary;
                        es.Tax = item.tax;
                        es.Benifits = item.benifits;
                        es.HourPrice = item.hourprice;
                        es.TotalHourPrice = item.totalhourPrice;
                        es.Withdraw = item.withdraw;
                        es.NetSalary = Convert.ToInt32(item.netsalary + item.totalhourPrice);
                        es.PaymentStatus = Convert.ToInt32(item.paymentstatus);
                    }
                    i = i.GroupBy(x => x.EmployeeId).Select(x => x.First()).ToList();
                    i.Add(es);
                }
                return View(i);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EmployeeSalaryDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" || 
                HttpContext.Session.GetString("UserRole") == "2" && 
                HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var emps = db.EmployeeSalary.AsNoTracking().ToList();
                var u = db.Employee.Where(q => q.EmployeeId == id).FirstOrDefault();
                var a = db.Attendance.AsNoTracking().ToList();
                var query = (from es in db.EmployeeSalary
                             join employee in db.Employee on es.EmployeeId equals employee.EmployeeId
                             join at in db.Attendance on es.AttendanceId equals at.AttendanceId
                             where es.SalaryId == id
                             select new
                             {
                                 salaryid = es.SalaryId,
                                 employeeid = employee.EmployeeId,
                                 firstname = employee.FirstName,
                                 lastname = employee.LastName,
                                 attendanceid = at.AttendanceId,
                                 loginduration = at.LoginDuration,
                                 basicsalary = es.BasicSalary,
                                 tax = es.Tax / 100,
                                 benifits = es.Benifits,
                                 hourprice = es.HourPrice,
                                 totalhourPrice = at.LoginDuration * es.HourPrice,
                                 withdraw = es.Withdraw,
                                 netsalary = ((es.BasicSalary + es.Benifits) - es.Tax),
                                 paymentstatus = (es.NetSalary - es.Withdraw)
                             });
                EmployeeSalaryVM esvm = new EmployeeSalaryVM();
                foreach (var item in query)
                {
                    esvm.SalaryId = item.salaryid;
                    esvm.EmployeeId = item.employeeid;
                    esvm.FirstName = item.firstname;
                    esvm.LastName = item.lastname;
                    esvm.AttendanceId = item.attendanceid;
                    esvm.LoginDuration = item.loginduration;
                    esvm.BasicSalary = item.basicsalary;
                    esvm.Tax = item.tax;
                    esvm.Benifits = item.benifits;
                    esvm.HourPrice = item.hourprice;
                    esvm.TotalHourPrice = item.totalhourPrice;
                    esvm.Withdraw = item.withdraw;
                    esvm.NetSalary = item.netsalary + item.totalhourPrice;
                    esvm.PaymentStatus = Convert.ToInt32(item.paymentstatus);
                }
                return View(esvm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateEmployeeSalary(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item1 = db.Employee.AsNoTracking().ToList();
                ViewBag.Employeeid = new SelectList(item1, "EmployeeId", "EmployeeId");

                var item2 = db.Employee.AsNoTracking().ToList();
                ViewBag.BasicSalary = new SelectList(item2, "BasicSalary", "BasicSalary");

                var item3 = db.Attendance.AsNoTracking().ToList();
                ViewBag.Attendanceid = new SelectList(item3, "AttendanceId", "EmployeeId");

                var item = db.EmployeeSalary.AsNoTracking().Where(a => a.SalaryId == id).FirstOrDefault();
                EmployeeSalaryVM urv = new EmployeeSalaryVM()
                {
                    SalaryId = item.SalaryId,
                    BasicSalary = item.BasicSalary,
                    Tax = item.Tax,
                    Benifits = item.Benifits,
                    HourPrice = item.HourPrice,
                    TotalHourPrice = item.TotalHourPrice,
                    Withdraw = item.Withdraw,
                    NetSalary = item.NetSalary,
                    PaymentStatus = item.PaymentStatus,
                    EmployeeId = item.EmployeeId,
                    AttendanceId = item.AttendanceId
                };
                return View(urv);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployeeSalary(EmployeeSalaryVM model)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var item2 = db.EmployeeSalary.AsNoTracking().Where(a => a.SalaryId == model.SalaryId).FirstOrDefault();
                Attendance item = new Attendance();
                if (model.BasicSalary > 50000)
                {
                    model.Tax = model.BasicSalary * 1 / 100;
                }
                else if (model.BasicSalary > 30000)
                {
                    model.Tax = model.BasicSalary * .5 / 100;
                }
                else
                {
                    model.Tax = 0;
                }
                // basic salary / number of working days in month * actual work
                int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                var perDaySalary = model.BasicSalary / days;
                var offdays = perDaySalary * 8;
                double hourPrice = perDaySalary / 24;
                model.HourPrice = hourPrice;
                //var minutesWorked = (model.LoginDuration.TotalHours * 60 + model.LoginDuration.TotalMinutes)/* - (model.LoginTime.Hours * 60 + model.LoginTime.Minutes)*/;
                //double hoursWorked = (double)minutesWorked / 60;
                //double totalHourPrice = (double)minutesWorked * (model.HourPrice / 60);
                model.TotalHourPrice = item.LoginDuration * model.HourPrice;
                model.NetSalary = (model.BasicSalary + model.Benifits + model.TotalHourPrice) - model.Tax;
                model.PaymentStatus = Convert.ToInt32(model.NetSalary - model.Withdraw);

                if (ModelState.IsValid)
                {
                    EmployeeSalary ur = new EmployeeSalary();
                    ur.SalaryId = model.SalaryId;
                    ur.BasicSalary = model.BasicSalary;
                    ur.Tax = model.Tax;
                    ur.Benifits = model.Benifits;
                    ur.HourPrice = model.HourPrice;
                    ur.TotalHourPrice = model.TotalHourPrice;
                    ur.NetSalary = model.NetSalary;
                    ur.Withdraw = model.Withdraw;
                    ur.PaymentStatus = model.PaymentStatus;
                    ur.EmployeeId = model.EmployeeId;
                    ur.AttendanceId = model.AttendanceId;
                    db.EmployeeSalary.Update(ur);
                    db.SaveChanges();
                }
                ViewBag.Success = "Employee Salary Updated Successfully.";
                return RedirectToAction("EmployeeSalaryList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteEmployeeSalary(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var emps = db.EmployeeSalary.AsNoTracking().ToList();
                var u = db.Employee.Where(q => q.EmployeeId == id).FirstOrDefault();
                var a = db.Attendance.AsNoTracking().ToList();
                var query = (from es in db.EmployeeSalary
                             join employee in db.Employee on es.EmployeeId equals employee.EmployeeId
                             join at in db.Attendance on es.AttendanceId equals at.AttendanceId
                             where es.SalaryId == id
                             select new
                             {
                                 salaryid = es.SalaryId,
                                 employeeid = employee.EmployeeId,
                                 firstname = employee.FirstName,
                                 lastname = employee.LastName,
                                 attendanceid = at.AttendanceId,
                                 loginduration = at.LoginDuration,
                                 basicsalary = es.BasicSalary,
                                 tax = es.Tax / 100,
                                 benifits = es.Benifits,
                                 hourprice = es.HourPrice,
                                 totalhourPrice = at.LoginDuration * es.HourPrice,
                                 withdraw = es.Withdraw,
                                 netsalary = ((es.BasicSalary + es.Benifits) - es.Tax),
                                 paymentstatus = (es.NetSalary - es.Withdraw)
                             });
                EmployeeSalaryVM esvm = new EmployeeSalaryVM();
                foreach (var item in query)
                {
                    esvm.SalaryId = item.salaryid;
                    esvm.EmployeeId = item.employeeid;
                    esvm.FirstName = item.firstname;
                    esvm.LastName = item.lastname;
                    esvm.AttendanceId = item.attendanceid;
                    esvm.LoginDuration = item.loginduration;
                    esvm.BasicSalary = item.basicsalary;
                    esvm.Tax = item.tax;
                    esvm.Benifits = item.benifits;
                    esvm.HourPrice = item.hourprice;
                    esvm.TotalHourPrice = item.totalhourPrice;
                    esvm.Withdraw = item.withdraw;
                    esvm.NetSalary = item.netsalary + item.totalhourPrice;
                    esvm.PaymentStatus = Convert.ToInt32(item.paymentstatus);
                }
                return View(esvm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteEmployeeSalary(EmployeeSalaryVM item)
        {
            if (HttpContext.Session.GetString("UserRole") == "1" && HttpContext.Session.GetString("UserRole") != "Expired")
            {
                var i = db.EmployeeSalary.AsNoTracking().Where(a => a.SalaryId == item.SalaryId).FirstOrDefault();
                db.EmployeeSalary.Remove(i);
                db.SaveChanges();
                return RedirectToAction("EmployeeSalaryList");
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
                var item = db.EmployeeSalary.AsNoTracking().Where(s => s.SalaryId == id).FirstOrDefault();
                EmployeeSalaryVM urv = new EmployeeSalaryVM()
                {
                    SalaryId = item.SalaryId,
                    BasicSalary = item.BasicSalary,
                    Tax = item.Tax,
                    Benifits = item.Benifits,
                    HourPrice = item.HourPrice,
                    TotalHourPrice = item.TotalHourPrice,
                    Withdraw = item.Withdraw,
                    NetSalary = item.NetSalary,
                    PaymentStatus = item.PaymentStatus,
                    EmployeeId = item.EmployeeId,
                    AttendanceId = item.AttendanceId
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
