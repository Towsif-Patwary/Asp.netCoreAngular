using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(200)")]
        public string FullName { get; set; }
        public string Preference { get; set; }
        public ICollection<PlaceModel> Places { get; set; }

    }
}
