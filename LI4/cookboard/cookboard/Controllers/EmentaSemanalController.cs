using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookboard.Models;

namespace cookboard.Controllers
{
    public class EmentaSemanalController : Controller
    {
        private readonly cookBoardContext co;
        public EmentaSemanalController(cookBoardContext context)
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

        public ActionResult getEmentaSemanal()
        {
            var size = (from m in co.EmentaSemanal select m).ToList().Count;

            List<Receita> receita = (from m in co.EmentaSemanalReceita
                          join n in co.Receita on m.ReceitaId equals n.Id
                          where (m.EmentaSemanalId == size)
                          select n).ToList();
            
            List<string> dias = (from m in co.EmentaSemanalReceita
                          where (m.EmentaSemanalId == size)
                          select m.Dia).ToList();

            var num = dias.Count;

            List<EmentaViewModel> final = new List<EmentaViewModel>();

            for (int i=0; i<num; i++)
            {
                Receita r = receita[i];
                string d = dias[i];

                final.Add(new EmentaViewModel(d, r));
            }

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(final);
        }

        public ActionResult getIngredientes()
        {
            var size = (from m in co.EmentaSemanal select m).ToList().Count;

            var ing = (from m in co.EmentaSemanalReceita
                          join n in co.Receita on m.ReceitaId equals n.Id
                          join ri in co.ReceitaIngrediente on n.Id equals ri.ReceitaId
                          join i in co.Ingrediente on ri.IngredienteId equals i.Id
                          where (m.EmentaSemanalId == size)
                          select i).ToHashSet();

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(ing);
        }

        [HttpGet]
        public ActionResult RegisterEmenta()
        {
            List<Receita> receitas = (from ri in co.Receita
                                      select ri).ToList();

            return View(new RegisterReceitaModel(receitas));
        }

        public void geraReceitaEmentaSemanal(String receitaI, String dia, int idEmenta)
        {
            var receita = (from m in co.Receita where (m.Nome == receitaI) select m).FirstOrDefault();
            EmentaSemanalReceita er = new EmentaSemanalReceita();
            er.EmentaSemanalId = idEmenta;
            er.ReceitaId = receita.Id;
            er.Dia = dia;
            co.EmentaSemanalReceita.Add(er);
            co.SaveChanges();
        }

        [HttpPost]
        public ActionResult RegisterEmenta(DateTime data, String receitaS, String receitaT, String receitaQ, String receitaQuinta, String receitaSexta)
        {
            EmentaSemanal e = new EmentaSemanal();
            co.EmentaSemanal.Add(e);
            e.DataLancamento = data;
            e.UtilizadorUsername = User.Identity.Name;
            co.SaveChanges();
            geraReceitaEmentaSemanal(receitaS, "Segunda-Feira", e.Id);
            geraReceitaEmentaSemanal(receitaT, "Terça-Feira", e.Id);
            geraReceitaEmentaSemanal(receitaQ, "Quarta-Feira", e.Id);
            geraReceitaEmentaSemanal(receitaQuinta, "Quinta-Feira", e.Id);
            geraReceitaEmentaSemanal(receitaSexta, "Sexta-Feira", e.Id);
            return RedirectToAction("Index", "Professor");
        }
    }
}

