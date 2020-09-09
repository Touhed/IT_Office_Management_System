using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.ViewModels
{
    public class AssignTaskVM
    {
        [Key]
        public int TaskId { get; set; }

        [StringLength(150)]
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public int Progress { get; set; }

    }
}
