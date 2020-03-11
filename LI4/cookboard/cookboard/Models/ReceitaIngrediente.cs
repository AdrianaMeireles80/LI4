using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class ReceitaIngrediente
    {
        public int ReceitaId { get; set; }
        public int IngredienteId { get; set; }
        public string Quantidade { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Receita Receita { get; set; }
    }
}
