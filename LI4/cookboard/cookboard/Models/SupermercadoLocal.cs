using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class SupermercadoLocal
    {
        public int SupermercadoId { get; set; }
        public int LocalId { get; set; }

        public virtual Local Local { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }
}
