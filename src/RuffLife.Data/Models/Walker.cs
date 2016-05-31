﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Models
{
    class Walker:BaseModel
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public double CostPerHour { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReviewForDog> ReviewsGiven { get; set; }
        public virtual ICollection<ReviewForWalker> ReviewsReceived { get; set; }
        public virtual ICollection<Walk> Walks { get; set; }
    }
}
