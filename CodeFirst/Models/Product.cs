using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Product : Entity
    {
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public Round Round { get; set; }

        public List<Part> Parts{ get; set; }
    }
}
