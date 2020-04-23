using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class PartDefinition : Entity
    {
        public int Cost { get; set; }

        public string Name { get; set; }
        
        public List<Part> Parts { get; set; }
    }
}
