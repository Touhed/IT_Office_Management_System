using ITOfficeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.ViewModels
{
    public class UserVM
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Type is mendatory.")]
        [StringLength(50)]
        public string UserType { get; set; }

        [Required(ErrorMessage = "User name is mendatory.")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is mendatory!")]
        [StringLength(50)]
        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Scary Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mendatory!")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Doesn't Match!")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password does not matched!")]
        public string ConfirmPassword { get; set; }
        
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
