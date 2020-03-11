using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookboard.Models;
using cookboard._Shared;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace cookboard.Controllers
{
    [Route("[controller]/[action]")]
    public class UtilizadorController : Controller
    {
        private readonly cookBoardContext co;
        public UtilizadorController(cookBoardContext context)
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

        public IActionResult getHistorico()
        {
            string username = User.Identity.Name;
            var receitas = (from m in co.UtilizadorReceita
                            join n in co.Receita on m.ReceitaId equals n.Id
                            where (m.UtilizadorUsername == username)
                            select n).ToList();

            ViewData["Type"] = userType(username);
            return View(receitas);
        }

        public IActionResult getFavoritos()
        {
            string username = User.Identity.Name;
            var receitas = (from m in co.UtilizadorReceita
                            join n in co.Receita on m.ReceitaId equals n.Id
                            where (m.UtilizadorUsername == username && m.Favorito == 1)
                            select n).ToList();

            ViewData["Type"] = userType(username);
            return View(receitas);
        }

        public ActionResult consultar(int idReceita)
        {
            var receita = (from m in co.Receita where (m.Id == idReceita) select m).ToList();

            string username = User.Identity.Name;

            ViewData["Type"] = userType(username);
            return View(receita);
        }

        [HttpGet]
        public IActionResult editarP()
        {
            string username = User.Identity.Name;
            var u = (from m in co.Utilizador where m.Username == username select m).FirstOrDefault();
            ViewData["Type"] = userType(username);
            return View(u);
        }
        [HttpPost]

        public IActionResult editarP(string nome, string email, string password)
        {
            string username = User.Identity.Name;
            var u = (from m in co.Utilizador where m.Username == username select m).FirstOrDefault();
            u.Nome = nome;
            u.Email = email;
            u.Password = MyHelper.HashPassword(password);
            co.Entry(u).State = EntityState.Modified;
            co.SaveChanges();
            TempData["Success"] = "Changed successfully";
            ViewData["Type"] = userType(username);
            return View(u);
        }

        public IActionResult removeFavoritos(int idReceita)
        {
            string username = User.Identity.Name;
            var ur = (from m in co.UtilizadorReceita
                      join n in co.Receita on m.ReceitaId equals n.Id
                      where (m.UtilizadorUsername == username && m.ReceitaId == idReceita)
                      select m).FirstOrDefault();
            int id = ur.ReceitaId;
            ur.Favorito = 0;
            co.Entry(ur).State = EntityState.Modified;
            co.SaveChanges();
            ViewData["Type"] = userType(username);
            return RedirectToAction("getFavoritos");
        }
    }
}