using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class StationAssemblyStep : Entity
    {
        public virtual AssemblyStep AssemblyStep { get; set; }

        public virtual Station Station { get; set; }

                
    }
}