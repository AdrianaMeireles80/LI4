using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class Supermercado
    {
        public Supermercado()
        {
            IngredienteSupermercado = new HashSet<IngredienteSupermercado>();
            SupermercadoLocal = new HashSet<SupermercadoLocal>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<IngredienteSupermercado> IngredienteSupermercado { get; set; }
        public virtual ICollection<SupermercadoLocal> SupermercadoLocal { get; set; }
    }
}
