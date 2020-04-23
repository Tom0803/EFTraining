using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class StationAssemblyStep
    {
        public long StationId { get; set; }
        public long AssemblyStepId { get; set; }

        public virtual AssemblyStep AssemblyStep { get; set; }
        public virtual Station Station { get; set; }
    }
}
