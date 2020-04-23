using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public long RoundId { get; set; }

        public virtual Round Round { get; set; }
    }
}
