using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAssistbyTowsif.Models.VM
{
    public class PlaceVm
    {
        [Required]
        public int PlaceId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public IFormFile image { get; set; } 

        //public HttpPostedFileBase ImageFile { get; set; }
        public int UserId { get; set; }
        public int PreferenceId { get; set; }
    }
}
