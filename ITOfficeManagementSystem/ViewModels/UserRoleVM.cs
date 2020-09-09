using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.ViewModels
{
    public class UserRoleVM
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required(ErrorMessage = "Type is mendatory.")]
        public string UserType { get; set; }

        public int Serial { get; set; }
    }
}
