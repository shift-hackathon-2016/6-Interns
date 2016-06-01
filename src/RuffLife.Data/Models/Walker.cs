using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    public class Walker:BaseModel
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public double CostPerHourInHRK { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Walk> Walks { get; set; }
    }
}
