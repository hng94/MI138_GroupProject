using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MI138_GroupProject.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ScreenshotUrl { get; set; }
        public string Tags { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public bool Published { get; set; } = false;
    }

    //public class GameDbContext: DbContext
    //{
    //    public DbSet<Game> Games { get; set; }
    //}
}