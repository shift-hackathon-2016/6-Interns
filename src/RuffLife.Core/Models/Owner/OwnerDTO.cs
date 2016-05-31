using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = RuffLife.Data.Models;

namespace RuffLife.Core.Models.Owner
{
    public class CreateOwnerDto
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<data.Dog> Dogs { get; set; }
    }

    public class ViewOwnerDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<data.ReviewForWalker> ReviewsGiven { get; set; }
        public virtual ICollection<data.Dog> Dogs { get; set; }
    }
}
