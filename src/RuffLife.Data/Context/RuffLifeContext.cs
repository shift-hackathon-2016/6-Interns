using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RuffLife.Data.Context.Configurations;
using RuffLife.Data.Models;

namespace RuffLife.Data.Context
{
    public class RuffLifeContext : DbContext
    {
        public RuffLifeContext()
            :base("RuffLifeContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Walker> Walkers { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new OwnerConfiguration());
            modelBuilder.Configurations.Add(new WalkerConfiguration());
            modelBuilder.Configurations.Add(new DogConfiguration());



        }
    }
}
