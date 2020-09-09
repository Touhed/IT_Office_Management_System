using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITOfficeManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string Reliability { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string Design { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string EaseOfUse { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string Security { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string AbilityToIntegrate { get; set; }

        [Required(ErrorMessage = "This is mendatory!")]
        [StringLength(50)]
        public string AbilityToCollaborate { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }
    }
}
