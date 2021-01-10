using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAssistbyTowsif.Models.VM
{
    public class UserVm
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [Display(Name ="User Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [Column(TypeName = "nvarchar(200)")]
        public string FullName { get; set; }
        public int PreferenceId { get; set; }

    }
}
