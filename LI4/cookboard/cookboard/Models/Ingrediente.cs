using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredienteSupermercado = new HashSet<IngredienteSupermercado>();
            ReceitaIngrediente = new HashSet<ReceitaIngrediente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<IngredienteSupermercado> IngredienteSupermercado { get; set; }
        public virtual ICollection<ReceitaIngrediente> ReceitaIngrediente { get; set; }
    }
}
