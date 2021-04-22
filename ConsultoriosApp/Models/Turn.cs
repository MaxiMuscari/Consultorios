using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultoriosApp
{
    public class Turn
    {
        public Guid Id { get; set; }
        public DateTime Schedule { get; set; }
        public bool Paid { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Medic Medic { get; set; }
    }
}
