using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MI138_GroupProject.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int MyProperty { get; set; }
    }

    //public class CommentDbContext: DbContext
    //{
    //    public DbSet<Comment> Comments { get; set; }
    //}
}