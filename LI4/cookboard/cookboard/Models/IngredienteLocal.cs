using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class IngredienteLocal
    {
        public int IngredienteId { get; set; }
        public int LocalId { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Local Local { get; set; }
    }
}
