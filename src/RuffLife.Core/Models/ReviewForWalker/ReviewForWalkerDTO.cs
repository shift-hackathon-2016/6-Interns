using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = RuffLife.Data.Models;

namespace RuffLife.Core.Models.ReviewForWalker
{
    public class CreateReviewForWalkerDto
    {
        public int Grade { get; set; }
        public string Review { get; set; }
        public virtual data.Walker Walker { get; set; }
        public virtual data.Owner Owner { get; set; }
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
        public virtual data.Walker Walker { get; set; }
        public virtual data.Owner Owner { get; set; }
    }
}
