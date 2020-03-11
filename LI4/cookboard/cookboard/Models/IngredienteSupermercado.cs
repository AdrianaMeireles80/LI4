using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public partial class IngredienteSupermercado
    {
        public int IngredienteId { get; set; }
        public int SupermercadoId { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }
}
