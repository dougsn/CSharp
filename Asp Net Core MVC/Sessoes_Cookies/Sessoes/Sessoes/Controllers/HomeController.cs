using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sessoes.Models;

namespace Sessoes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            HttpContext.Session.SetString("Pessoa", "Thiago");
            HttpContext.Session.SetInt32("Idade",29);
            HttpContext.Session.SetString("HorarioAtual", DateTime.Now.ToString());


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["Pessoa"] = HttpContext.Session.GetString("Pessoa");
            ViewData["Idade"] = HttpContext.Session.GetInt32("Idade");
            ViewData["HorarioAtual"] = HttpContext.Session.GetString("HorarioAtual");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
