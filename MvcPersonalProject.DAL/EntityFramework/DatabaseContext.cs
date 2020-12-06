using MvcPersonalProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPersonalProject.DAL.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<About> About { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ProjectsDones> ProjectsDones { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Experiences> Experiences { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }
    }
}
