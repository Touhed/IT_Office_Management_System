using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class AssignTask
    {
        [Key]
        public int TaskId { get; set; }

        [StringLength(150)]
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
    }
}
