using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class AssemblyStep : Entity
    {
        public long Cost { get; set; }

        public string Name { get; set; }

        public List<StationAssemblyStep> StationAssemblySteps { get; set; }
    }
}
