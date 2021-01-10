using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAssistbyTowsif.Models.VM
{
    public class PreferenceVm
    {
        [Required]
        public int PreferenceId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Preference { get; set; }
    }
}
