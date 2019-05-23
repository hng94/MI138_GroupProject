using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCompany.Models
{

    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(DbContextOptions options)
             : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<GameCompany> Game_company { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Tag> Tag { get; set; }
    }
}
