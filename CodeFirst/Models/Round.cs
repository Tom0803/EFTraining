using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Round : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public List<Product> Products { get; set; }
        public List<Station> Stations { get; set; }

        public override string ToString() => $"Start - [{Start}] - Stations [{Stations?.Count}] - Products [{Products?.Count}]]";
    }
}
