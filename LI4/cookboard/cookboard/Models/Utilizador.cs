using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cookboard.Models
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            EmentaSemanal = new HashSet<EmentaSemanal>();
            Receita = new HashSet<Receita>();
            UtilizadorReceita = new HashSet<UtilizadorReceita>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<EmentaSemanal> EmentaSemanal { get; set; }
        public virtual ICollection<Receita> Receita { get; set; }
        public virtual ICollection<UtilizadorReceita> UtilizadorReceita { get; set; }
    }
}

