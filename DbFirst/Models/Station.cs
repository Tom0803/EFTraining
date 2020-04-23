using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Station
    {
        public long Id { get; set; }
        public string Position { get; set; }
        public long RoundId { get; set; }

        public virtual Round Round { get; set; }
    }
}
