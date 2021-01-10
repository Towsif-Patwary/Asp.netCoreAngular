using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAssistbyTowsif.Models.VM
{
    public class CommentVm
    {
        [Required]
        public int CommentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Comment { get; set; }
        //public DateTime? DateOfComment { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
    }
}
