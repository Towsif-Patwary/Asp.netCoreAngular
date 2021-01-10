using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class PreferenceModel
    {
        [Key]
        public int PreferenceId { get; set; }
        public string Preference { get; set; }
    }
}
