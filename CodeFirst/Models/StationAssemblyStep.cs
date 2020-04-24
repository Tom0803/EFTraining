using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class StationAssemblyStep : Entity
    {
        public AssemblyStep AssemblyStep { get; set; }

        public Station Station { get; set; }                
    }
}