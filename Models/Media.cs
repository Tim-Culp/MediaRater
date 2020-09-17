using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaRater.Models
{
    public enum Ratings {
        G = 0,
        PG = 1,
        PG_13 = 2,
        R = 3,
        NR = 4}
    public class Media
    {
        [Key]
        public int MediaID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Age Rating")]
        public Ratings AgeRating { get; set; }

    }
}