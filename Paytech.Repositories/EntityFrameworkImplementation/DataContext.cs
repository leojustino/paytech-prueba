using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;

namespace Paytech.Repositories.EntityFrameworkImplementation
{
    class DataContext : DbContext
    {
        public DataContext()
             : base(RepositoryFactory.CONNECTION_STRING)
        {              
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Person>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Person> People { get; set; }

    }
}
