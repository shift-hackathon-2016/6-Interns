using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.Walker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Models.Walk
{
    public class CreateWalkDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public virtual ICollection<ViewDogDto> Dogs { get; set; }
    }

    public class UpdateWalkDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
    }

    public class ViewWalkDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }

        public virtual ViewWalkerDto Walker { get; set; }
        public virtual ICollection<ViewDogDto> Dogs { get; set; }
    }
}
