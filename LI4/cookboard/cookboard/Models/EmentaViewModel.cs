using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public class EmentaViewModel
    {
        public EmentaViewModel(string dia, Receita receita)
        {
            Dia = dia;
            Receita = receita;
        }

        public string Dia { get; set; }
        public Receita Receita { get; set; }
    }
}
