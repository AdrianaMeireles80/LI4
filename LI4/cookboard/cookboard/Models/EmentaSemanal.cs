using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class EmentaSemanal
    {
        public EmentaSemanal()
        {
            EmentaSemanalReceita = new HashSet<EmentaSemanalReceita>();
        }

        public int Id { get; set; }
        public string UtilizadorUsername { get; set; }
        public DateTime DataLancamento { get; set; }

        public virtual Utilizador UtilizadorUsernameNavigation { get; set; }
        public virtual ICollection<EmentaSemanalReceita> EmentaSemanalReceita { get; set; }
    }
}
