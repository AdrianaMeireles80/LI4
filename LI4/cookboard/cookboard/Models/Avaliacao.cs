using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookboard.Models
{
    public partial class Avaliacao
    {
        public int Id { get; set; }
        public int Estrela { get; set; }
        public string Comentario { get; set; }
        public int ReceitaId { get; set; }

        public virtual Receita Receita { get; set; }
    }
}