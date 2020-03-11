using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookboard.Models;

namespace cookboard.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly cookBoardContext co;
        public ReceitasController(cookBoardContext context)
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

        public ActionResult getReceitas()
        {
            var receitas = (from m in co.Receita select m);

            List<Receita> lista = receitas.ToList<Receita>();

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(lista);
        }

        public ActionResult getReceita(int idReceita)
        {

            List<Ingrediente> ing = (from ri in co.ReceitaIngrediente 
                                   join i in co.Ingrediente on ri.IngredienteId equals i.Id
                                   where (ri.ReceitaId == idReceita)
                                   select i).ToList();

            List<string> quant = (from ri in co.ReceitaIngrediente
                                  where (ri.ReceitaId == idReceita)
                                  select ri.Quantidade).ToList();

            List<IngredienteViewModel> final = new List<IngredienteViewModel>();
            int num = ing.Count();

            for (int i = 0; i < num; i++)
            {
                Ingrediente ingrediente = ing[i];
                string quantidade = quant[i];

                final.Add(new IngredienteViewModel(quantidade, ingrediente));
            }

            Receita rec = (from n in co.Receita
                       where (n.Id == idReceita)
                       select n).Single();

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(new ReceitaViewModel(rec, final));
        }

        public ActionResult getPassos(int idReceita)
        {
            Receita rec = (from n in co.Receita
                           where (n.Id == idReceita)
                           select n).Single();

            List<ReceitaReceitaAuxiliar> ajudas = (from ri in co.ReceitaReceitaAuxiliar
                                                where (ri.ReceitaId == idReceita)
                                                select ri).ToList();

            List<PassosViewModel> passos = new List<PassosViewModel>();
            string[] words = rec.Descricao.Split('.');
            int tam = words.Length;

            for(int j=0; j<tam-1; j++)
            {
                string type;
                int idAux = -1;
                if (j == 0) type = "primeiro";
                else if (j == tam - 2) type = "ultimo";
                else type = "intermedio";
                foreach(var aux in ajudas)
                {
                    if(aux.Passo == j + 1)
                    {
                        int id = aux.ReceitaAuxiliarId;
                        Receita r = (from n in co.Receita
                                     where (n.Id == id)
                                     select n).Single();
                        idAux = r.Id;
                    }
                }
                passos.Add(new PassosViewModel(j + 1, words[j], j + 2, j, type, idAux, idReceita, -1));
            }

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(passos);
        }

        public ActionResult getPassosAuxiliar(int idReceita, int idReceitaInit)
        {
            Receita rec = (from n in co.Receita
                           where (n.Id == idReceita)
                           select n).Single();

            List<ReceitaReceitaAuxiliar> ajudas = (from ri in co.ReceitaReceitaAuxiliar
                                                   where (ri.ReceitaId == idReceita)
                                                   select ri).ToList();

            List<PassosViewModel> passos = new List<PassosViewModel>();
            string[] words = rec.Descricao.Split('.');
            int tam = words.Length;

            for (int j = 0; j < tam - 1; j++)
            {
                string type;
                int idAux = -1;
                if (j == 0) type = "primeiro";
                else if (j == tam - 2) type = "ultimo";
                else type = "intermedio";
                foreach (var aux in ajudas)
                {
                    if (aux.Passo == j + 1)
                    {
                        int id = aux.ReceitaAuxiliarId;
                        Receita r = (from n in co.Receita
                                     where (n.Id == id)
                                     select n).Single();
                        idAux = r.Id;
                    }
                }
                passos.Add(new PassosViewModel(j + 1, words[j], j + 2, j, type, idAux, idReceita, idReceitaInit));
            }

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(passos);
        }

        [HttpGet]
        public IActionResult RegisterReceita()
        {
            List<Receita> receitas = (from ri in co.Receita
                                      select ri).ToList();
            string username = User.Identity.Name;
            ViewData["Type"] = userType(username);
            return View(new RegisterReceitaModel(receitas));
        }

        public bool registerIngrediente(int receitaId, string ingrediente)
        {
            string[] words = ingrediente.Split('.');
            foreach (var word in words)
            {
                string[] info = word.Split("-");
                if (info.Length > 1)
                {
                    int id;
                    var Ingrediente = (from m in co.Ingrediente where (info[0] == m.Nome) select m).FirstOrDefault();
                    if (Ingrediente == null)
                    {
                        Ingrediente ing = new Ingrediente();
                        ing.Nome = info[0];
                        co.Ingrediente.Add(ing);
                        co.SaveChanges();
                        id = ing.Id;
                    }
                    else id = Ingrediente.Id;
                    ReceitaIngrediente ri = new ReceitaIngrediente();
                    ri.ReceitaId = receitaId;
                    ri.IngredienteId = id;
                    ri.Quantidade = info[1];
                    co.ReceitaIngrediente.Add(ri);
                    co.SaveChanges();
                }
            }

            return true;
        }

        public bool registerReceita(Receita receita, string ingrediente, string receitaAux, int passo)
        {
            string username = User.Identity.Name;
            receita.UtilizadorUsername = username;
            co.Receita.Add(receita);
            co.SaveChanges();
            if (!receitaAux.Equals("receitaAux"))
            {
                ReceitaAuxiliar r = new ReceitaAuxiliar();
                var re = (from m in co.Receita where m.Nome == receitaAux select m).FirstOrDefault();
                r.Id = re.Id;
                co.ReceitaAuxiliar.Add(r);
                co.SaveChanges();
                ReceitaReceitaAuxiliar ra = new ReceitaReceitaAuxiliar();
                ra.Passo = passo;
                ra.ReceitaId = receita.Id;
                ra.ReceitaAuxiliarId = re.Id;
                co.ReceitaReceitaAuxiliar.Add(ra);
                co.SaveChanges();
            }
            registerIngrediente(receita.Id, ingrediente);
            ViewData["Type"] = userType(username);
            return true;
        }

        [HttpPost]
        public IActionResult RegisterReceita([Bind] Receita receita, string ingrediente, string receitaAux, int passo)
        {
            bool RegistrationStatus = registerReceita(receita, ingrediente, receitaAux, passo);
            string username = User.Identity.Name;
            if (RegistrationStatus)
            {
                ModelState.Clear();
            }
            ViewData["Type"] = userType(username);
            return View();
        }

        [HttpGet]
        public ActionResult getAvaliacao(int idReceita)
        {
            string username = User.Identity.Name;

            var rec = (from n in co.Receita
                       where (n.Id == idReceita)
                       select n).Single();

            var ure = (from n in co.UtilizadorReceita
                       where (n.ReceitaId == idReceita && n.UtilizadorUsername == username)
                       select n).FirstOrDefault();

            if (ure == null)
            {
                UtilizadorReceita ur = new UtilizadorReceita();
                ur.Favorito = 0;
                ur.ReceitaId = idReceita;
                ur.UtilizadorUsername = username;
                co.UtilizadorReceita.Add(ur);
                co.SaveChanges();
            }
            ViewData["Type"] = userType(username);
            return View(rec);
        }

        [HttpPost]
        public ActionResult avaliar(string comentario, int estrelas, int idReceita)
        {
            var rec = (from n in co.Receita
                       where (n.Id == idReceita)
                       select n).Single();

            int id = idReceita;

            Avaliacao a = new Avaliacao();
            a.Comentario = comentario;
            a.Estrela = estrelas;
            a.ReceitaId = idReceita;
            co.Avaliacao.Add(a);
            co.SaveChanges();
            return RedirectToAction("getAvaliacao", new { idReceita = idReceita });
        }

        public ActionResult addFavorito(int idReceita)
        {
            string username = User.Identity.Name;

            var ur = (from n in co.UtilizadorReceita
                      where (n.ReceitaId == idReceita && n.UtilizadorUsername == username)
                      select n).Single();

            ur.Favorito = 1;
            co.SaveChanges();

            return RedirectToAction("getAvaliacao", new { idReceita = idReceita });
        }
    }
}