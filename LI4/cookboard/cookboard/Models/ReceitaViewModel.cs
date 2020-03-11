using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public class ReceitaViewModel
    {
        public ReceitaViewModel(Receita receita, List<IngredienteViewModel> ingredientes)
        {
            Receita = receita;
            Ingredientes = ingredientes;
        }

        public Receita Receita { get; set; }
        public List<IngredienteViewModel> Ingredientes { get; set; }
    }
}
