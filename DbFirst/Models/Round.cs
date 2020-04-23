using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Round
    {
        public Round()
        {
            Product = new HashSet<Product>();
            Station = new HashSet<Station>();
        }

        public long Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Station> Station { get; set; }
    }
}
