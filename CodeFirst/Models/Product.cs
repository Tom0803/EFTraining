﻿using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Product : Entity
    {
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public Round Round { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }

        public List<Part> Parts{ get; set; }

        public override string ToString() => $"Product\nId:[{Id}] - Start:[{Start}] - Round: [{Round?.ToString()}] - Station: [{Station}]";
    }
}
