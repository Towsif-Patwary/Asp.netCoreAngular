using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public virtual PlaceModel Place { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
