using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }

        [StringLength(150)]
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
