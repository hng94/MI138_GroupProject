using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MI138_GroupProject.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    //public class ReviewDbContext : DbContext
    //{
    //    public DbSet<Review> Reviews { get; set; }
    //} 
}