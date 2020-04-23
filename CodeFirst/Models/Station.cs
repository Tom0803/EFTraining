using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Station : Entity
    {
        public string Position { get; set; }

        public Round Round { get; set; }

        public List<StationAssemblyStep> StationAssemblySteps { get; set; }
    }
}
