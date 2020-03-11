using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookboard.Models;

namespace cookboard.Controllers
{
    public class LocalIngredienteController : Controller
    {
        private readonly cookBoardContext co;
        public LocalIngredienteController(cookBoardContext context)
        {
            //_context = context;
            co = context;
        }

        public string userType(string username)
        {
            var u = (from m in co.Utilizador
                     where (m.Username == username)
                     select m).FirstOrDefault();

            string tipo = u.Tipo;
            return tipo;
        }

        public ActionResult getLocalizacao(int idReceita)
        {
            var sup = (from ri in co.ReceitaIngrediente
                          join i in co.Ingrediente on ri.IngredienteId equals i.Id
                          join l in co.IngredienteSupermercado on i.Id equals l.IngredienteId
                          join lo in co.Supermercado on l.SupermercadoId equals lo.Id
                          where (ri.ReceitaId == idReceita)
                          select lo.Nome).ToHashSet();

            List<string> listaSup = sup.ToList<string>();

            var locais = (from ri in co.ReceitaIngrediente
                          join i in co.Ingrediente on ri.IngredienteId equals i.Id
                          join l in co.IngredienteSupermercado on i.Id equals l.IngredienteId
                          join ss in co.Supermercado on l.SupermercadoId equals ss.Id
                          join s in co.SupermercadoLocal on ss.Id equals s.SupermercadoId
                          join lo in co.Local on s.LocalId equals lo.Id
                          where (ri.ReceitaId == idReceita)
                          select lo).ToHashSet();

            List<Local> lista = locais.ToList<Local>();

            List<LocalIngredienteViewModel> final = new List<LocalIngredienteViewModel>();
            int num = sup.Count();

            for (int i = 0; i < num; i++)
            {
                string supermecado = listaSup[i];
                Local local = lista[i];

                final.Add(new LocalIngredienteViewModel(supermecado, local));
            }

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(final);
        }
    }
}