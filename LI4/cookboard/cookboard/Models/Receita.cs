using System;
using System.Collections.Generic;

namespace cookboard.Models
{
    public partial class Receita
    {
        public Receita()
        {
            Avaliacao = new HashSet<Avaliacao>();
            EmentaSemanalReceita = new HashSet<EmentaSemanalReceita>();
            ReceitaIngrediente = new HashSet<ReceitaIngrediente>();
            ReceitaReceitaAuxiliar = new HashSet<ReceitaReceitaAuxiliar>();
            UtilizadorReceita = new HashSet<UtilizadorReceita>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Porcao { get; set; }
        public string Imagem { get; set; }
        public string InfoNutricional { get; set; }
        public string Dificuldade { get; set; }
        public string Descricao { get; set; }
        public string TempoConfecao { get; set; }
        public string UtilizadorUsername { get; set; }

        public virtual Utilizador UtilizadorUsernameNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<EmentaSemanalReceita> EmentaSemanalReceita { get; set; }
        public virtual ICollection<ReceitaIngrediente> ReceitaIngrediente { get; set; }
        public virtual ICollection<ReceitaReceitaAuxiliar> ReceitaReceitaAuxiliar { get; set; }
        public virtual ICollection<UtilizadorReceita> UtilizadorReceita { get; set; }
    }
}