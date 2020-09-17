using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaRater.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        //[Required]
        //public Guid OwnerID { get; set; }
        [Required]
        [Display(Name = "Review")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Star Rating")]
        public int StarRating { get; set; }

        [Required]
        [ForeignKey("OnMedia")]
        //[HiddenInput(DisplayValue = false)]
        public int MediaID { get; set; }
        [Required]
        //[HiddenInput(DisplayValue = false)]
        public virtual Media OnMedia { get; set; }
    }
}