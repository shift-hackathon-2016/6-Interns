using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = RuffLife.Data.Models;

namespace RuffLife.Core.Models.Dog
{
    public class CreateDogDto
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public virtual data.Owner Owner { get; set; }
    }

    public class UpdateDogDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

    public class ViewDogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public virtual data.Owner Owner { get; set; }
        public virtual ICollection<data.ReviewForDog> ReviewsReceived { get; set; }
        public virtual ICollection<data.Walk> Walks { get; set; }
    }
}
