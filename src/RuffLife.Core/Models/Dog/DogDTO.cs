using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Core.Models.Walk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ViewOwnerDto Owner { get; set; }
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
        public virtual ViewOwnerDto Owner { get; set; }
        public virtual ICollection<ViewReviewForDogDto> ReviewsReceived { get; set; }
        public virtual ICollection<ViewWalkDto> Walks { get; set; }
    }
}
