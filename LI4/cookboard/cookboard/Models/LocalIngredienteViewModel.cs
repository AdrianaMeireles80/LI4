using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public class LocalIngredienteViewModel
    {
        public LocalIngredienteViewModel(string supermercado, Local local)
        {
            Supermercado = supermercado;
            Local = local;
        }

        public string Supermercado { get; set; }
        public Local Local { get; set; }
    }
}
