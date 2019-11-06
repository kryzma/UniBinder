using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniBinderAPI.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("UniBinderDb")
        {
            //Database.SetInitializer<DatabaseContext>(new DbInitialiazer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());

           modelBuilder.Entity<Person>()
                .ToTable("Person");
        }
         
        public DbSet<Person> People { get; set; }
    }
}