using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [StringLength(150)]
        public string EventTitle { get; set; }
        public string EventDetails { get; set; }
    }
}
