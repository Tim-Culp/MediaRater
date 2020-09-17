using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaRater.Models
{
    public class MediaCreate
    {
        public int MediaID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Age Rating")]
        public Ratings AgeRating { get; set; }

    }
}