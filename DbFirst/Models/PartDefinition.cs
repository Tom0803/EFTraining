using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class PartDefinition
    {
        public long Id { get; set; }
        public long Cost { get; set; }
        public string Text { get; set; }
    }
}
