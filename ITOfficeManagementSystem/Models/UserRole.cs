using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required(ErrorMessage = "Type is mendatory.")]
        public string UserType { get; set; }

    }
}
