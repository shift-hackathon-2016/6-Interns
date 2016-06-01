using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuffLife.Data.Models;

namespace RuffLife.Data.Context.Configurations
{
    public class DogConfiguration: EntityTypeConfiguration<Dog>
    {
        public DogConfiguration()
        {
            HasRequired(dog => dog.Owner)
                .WithMany(owner => owner.Dogs)
                .WillCascadeOnDelete(false);
            
            HasMany(d => d.Walks)
                .WithMany(walk => walk.Dogs)
                .Map(dogWalks => dogWalks
                    .MapLeftKey("DogId")
                    .MapRightKey("WalkId")
                    .ToTable("DogWalks"));
        }
    }
}
