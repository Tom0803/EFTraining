using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Models
{
    public partial class Station : Entity
    {
        public string Position { get; set; }

        public Round Round { get; set; }

        public List<StationAssemblyStep> StationAssemblySteps { get; set; }

        public override string ToString() => $"Station:Id [{Id}] - Position [{Position}]";
    }

    public static class StationExtensions
    {
        public static int PositionAsInt(this Station station)
        {
            char last = station.Position.Last();

            if (int.TryParse(last.ToString(), out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
