using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public class Part : Entity
    {
        public  PartDefinition PartDefintion { get; set; }
        public  Product Product { get; set; }
    }
}
