using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class PlaceModel
    {
        [Key]
        public int PlaceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public int UserId { get; set; }
        public string Preferences { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
    }
}
