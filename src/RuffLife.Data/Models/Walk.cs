using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    public class Walk:BaseModel
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }

        public virtual Walker Walker { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
