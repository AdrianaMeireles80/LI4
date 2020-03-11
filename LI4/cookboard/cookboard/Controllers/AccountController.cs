using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using cookboard._Shared;
using cookboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace cookboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly cookBoardContext co;
        public AccountController(cookBoardContext context)
        {
            //_context = context;
            co = context;
        }

        public bool ValidateUser(Utilizador user)
        {
            user.Password = MyHelper.HashPassword(user.Password);
            var returnedUser = co.Utilizador.Where(b => b.Username == user.Username && b.Password == user.Password).FirstOrDefault();

            if (returnedUser == null)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult utilizadorLogin()
        {
              return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> utilizadorLogin([Bind] Utilizador utilizador)
        {
            ModelState.Remove("Email");
            ModelState.Remove("Nome");
            ModelState.Remove("DataNascimento");
            ModelState.Remove("Tipo");

            if (utilizador.Username == "Admin" && utilizador.Password == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (ModelState.IsValid)
            {
                var LoginStatus = ValidateUser(utilizador);
                if (LoginStatus)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utilizador.Username)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    var tipo = (from m in co.Utilizador where (m.Username == utilizador.Username) select m.Tipo).FirstOrDefault();
                    if (tipo.Equals("Professor"))
                    {
                        ViewData["Type"] = tipo;
                        return RedirectToAction("Index", "Professor");
                    }
                    else {
                        ViewData["Type"] = tipo;
                        return RedirectToAction("Index", "Aluno");
                    }                
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegisterUtilizador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUtilizador([Bind] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador.Password = MyHelper.HashPassword(utilizador.Password);
                co.Utilizador.Add(utilizador);
                co.SaveChanges();
                ModelState.Clear();
                TempData["Success"] = "Registration Successful!";
            }
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
