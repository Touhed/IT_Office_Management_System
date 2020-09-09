using ITOfficeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.ViewModels
{
    public class AttendanceVM
    {
        [Key]
        public long AttendanceId { get; set; }
        public Boolean LoginStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd\-MM\-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh: mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LoginTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh: mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LogoutTime { get; set; }
        public double LoginDuration { get; set; }
        public double TotalDuration { get; set; }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Users Users { get; set; }
    }
}
