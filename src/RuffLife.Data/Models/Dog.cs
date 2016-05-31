using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    class Dog:BaseModel
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<ReviewForDog> ReviewsReceived { get; set; }
        public virtual ICollection<Walk> Walks { get; set; }
    }
}
