using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cookies.Models;
using Microsoft.AspNetCore.Http;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var visitante = Request.Cookies["Visitante"].ToString();
            if (visitante.Equals("Sim"))
            {
                return View("Visitante");
            }

            return View();
        }

        public IActionResult EscreverCookies()
        {
            CookieOptions cookie = new CookieOptions();

            cookie.Expires = DateTime.Now.AddHours(1);
            cookie.HttpOnly = true;
            cookie.Secure = true;

            Response.Cookies.Append("Visitante", "Sim", cookie);

            return RedirectToAction("Index");
        }

        public IActionResult ExcluirCookies()
        {

            Response.Cookies.Delete("Visitante");

            return RedirectToAction("Index");
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
