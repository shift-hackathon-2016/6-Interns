using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuffLife.Data.Models;

namespace RuffLife.Data.Context.Configurations
{
    public class OwnerConfiguration : EntityTypeConfiguration<Owner>
    {
        public OwnerConfiguration()
        {
            HasMany(o => o.Dogs)
               .WithRequired(d => d.Owner)
               .WillCascadeOnDelete(false);
            
        }
    }
}
