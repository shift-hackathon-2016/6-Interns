using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.Walker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Models.ReviewForDog 
{
    public class CreateReviewForDogDto
    {
        public int Grade { get; set; }
        public string Review { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
        public virtual ViewDogDto Dog { get; set; }
    }

    public class UpdateReviewForDogDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Review { get; set; }
    }

    public class ViewReviewForDogDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Review { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
        public virtual ViewDogDto Dog { get; set; }
    }
}
