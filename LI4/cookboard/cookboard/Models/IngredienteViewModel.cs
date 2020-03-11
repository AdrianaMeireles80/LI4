using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public class IngredienteViewModel
    {
        public IngredienteViewModel(string quantidade, Ingrediente ingrediente)
        {
            Quantidade = quantidade;
            Ingrediente = ingrediente;
        }

        public string Quantidade { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
