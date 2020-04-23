using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class AssemblyStep
    {
        public long Id { get; set; }
        public long Cost { get; set; }
        public string Name { get; set; }
    }
}
