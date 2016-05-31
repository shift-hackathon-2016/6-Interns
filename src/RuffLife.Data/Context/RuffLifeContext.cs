using System.Data.Entity;

namespace RuffLife.Data.Context
{
    public class RuffLifeContext : DbContext
    {
        public RuffLifeContext()
            :base("RuffLifeContext")
        {
            
        }
    }
}
