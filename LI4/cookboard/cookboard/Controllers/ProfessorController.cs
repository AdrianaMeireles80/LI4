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


namespace cookboard.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfessorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}