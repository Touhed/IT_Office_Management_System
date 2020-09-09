﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "First name is mendatory.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is mendatory.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is mendatory!")]
        [StringLength(50)]
        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Scary Email.")]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
}
