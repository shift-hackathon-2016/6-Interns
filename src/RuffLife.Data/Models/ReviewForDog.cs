using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    public class ReviewForDog:BaseModel
    {
        public int Grade { get; set; }
        public string Review { get; set; }

        public virtual Walker Walker { get; set; }
        public virtual Dog Dog { get; set; }
    }
}
