using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
