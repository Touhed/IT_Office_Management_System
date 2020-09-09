﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.ViewModels
{
    public class EmployeeSalaryVM
    {
        [Key]
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long AttendanceId { get; set; }
        public double LoginDuration { get; set; }
        public double TotalDuration { get; set; }
        public int BasicSalary { get; set; }
        public double Tax { get; set; }
        public int Benifits { get; set; }
        public double HourPrice { get; set; }
        public double TotalHourPrice { get; set; }
        public int Withdraw { get; set; }
        public double NetSalary { get; set; }
        public int PaymentStatus { get; set; }

    }
}
