using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Walker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Models.ReviewForWalker
{
    public class CreateReviewForWalkerDto
    {
        public int Grade { get; set; }
        public string Review { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
        public virtual ViewOwnerDto Owner { get; set; }
    }

    public class UpdateReviewForWalkerDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Review { get; set; }
    }

    public class ViewReviewForWalkerDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Review { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
        public virtual ViewOwnerDto Owner { get; set; }
    }
}
