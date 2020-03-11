using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cookboard.Models
{
    public class RegisterReceitaModel
    {
        public RegisterReceitaModel(List<Receita> receitas)
        {
            Receitas = receitas;
        }
        public List<Receita> Receitas { get; set; }
    }
}