using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class EmentaSemanalReceita
    {
        public int EmentaSemanalId { get; set; }
        public int ReceitaId { get; set; }
        public string Dia { get; set; }

        public virtual EmentaSemanal EmentaSemanal { get; set; }
        public virtual Receita Receita { get; set; }
    }
}
