using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class UtilizadorReceita
    {
        public string UtilizadorUsername { get; set; }
        public int ReceitaId { get; set; }
        public byte Favorito { get; set; }

        public virtual Receita Receita { get; set; }
        public virtual Utilizador UtilizadorUsernameNavigation { get; set; }
    }
}
