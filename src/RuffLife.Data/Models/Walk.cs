using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RuffLife.Data.Models
{
    public class Walk:BaseModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public virtual Walker Walker { get; set; }
        [JsonIgnore]
        public virtual ICollection<Dog> Dogs { get; set; }
        [JsonIgnore]
        public virtual ICollection<WalkOffer> WalkOffers { get; set; }
    }
}
