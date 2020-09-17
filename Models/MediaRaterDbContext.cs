using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediaRater.Models
{
    public class MediaRaterDbContext: DbContext
    {
        public DbSet<Media> Media { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}