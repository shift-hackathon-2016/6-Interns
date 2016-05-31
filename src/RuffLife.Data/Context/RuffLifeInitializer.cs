using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Context
{
    public class RuffLifeInitializer: System.Data.Entity.DropCreateDatabaseAlways<RuffLifeContext>
    {
        protected override void Seed(RuffLifeContext context)
        {
        }
    }
}
