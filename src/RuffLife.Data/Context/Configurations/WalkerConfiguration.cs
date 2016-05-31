using System.Data.Entity.ModelConfiguration;
using RuffLife.Data.Models;

namespace RuffLife.Data.Context.Configurations
{
    public class WalkerConfiguration : EntityTypeConfiguration<Walker>
    {
        public WalkerConfiguration()
        {
            HasMany(w => w.ReviewsReceived)
                .WithRequired(r => r.Walker)
                .WillCascadeOnDelete();

            HasMany(w => w.ReviewsGiven)
                .WithRequired(r => r.Walker)
                .WillCascadeOnDelete();

            HasMany(w => w.Walks)
                .WithRequired(walk => walk.Walker)
                .WillCascadeOnDelete();

        }
    }
}
