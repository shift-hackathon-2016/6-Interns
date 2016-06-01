
using RuffLife.Core.Models.Walk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Models.Walker
{
    public class CreateWalkerDto
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public double CostPerHourInHRK { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
    }

    public class ViewWalkerDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public double CostPerHourInHRK { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<ViewWalkDto> Walks { get; set; }
    }
}
