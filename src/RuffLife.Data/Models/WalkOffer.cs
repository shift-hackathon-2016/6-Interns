using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    public class WalkOffer:BaseModel
    {
        public bool IsActive { get; set; }

        public virtual Walk Walk { get; set; }
        public virtual ICollection<Walker> Walker { get; set; }
    }
}
