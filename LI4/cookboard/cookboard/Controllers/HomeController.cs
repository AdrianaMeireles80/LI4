using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookboard.Models;
using Microsoft.EntityFrameworkCore;


namespace cookboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly cookBoardContext co;
        public HomeController(cookBoardContext context)
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pesquisa(String search)
        {
            List<Receita> receitas = new List<Receita>();
            foreach (var r in co.Receita)
            {
                if (r.Nome.Contains(search)) receitas.Add(r);
            }
            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(receitas.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
