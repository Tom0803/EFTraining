using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Part
    {
        public long ProductId { get; set; }
        public long PartDefintionId { get; set; }

        public virtual PartDefinition PartDefintion { get; set; }
        public virtual Product Product { get; set; }
    }
}
