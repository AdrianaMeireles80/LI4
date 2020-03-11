using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class ReceitaAuxiliar
    {
        public ReceitaAuxiliar()
        {
            ReceitaReceitaAuxiliar = new HashSet<ReceitaReceitaAuxiliar>();
        }

        public int Id { get; set; }

        public virtual ICollection<ReceitaReceitaAuxiliar> ReceitaReceitaAuxiliar { get; set; }
    }
}

