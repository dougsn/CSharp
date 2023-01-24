using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cache.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {

        private readonly PessoasDBContext _contexto;
        private readonly IMemoryCache _cache;

        public HomeController(PessoasDBContext contexto, IMemoryCache cache)
        {
            _contexto = contexto;
            _cache = cache;
        }

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

            return View();
        }

        public IActionResult DadosComMemoriaCache()
        {
            List<Pessoas> pessoas;

            var opcoesCache = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60)); // duração do cache

            if(!_cache.TryGetValue("ListaPessoas", out pessoas))
            {
                pessoas = _contexto.Pessoas.ToList();

                _cache.Set("ListaPessoas", pessoas, opcoesCache); // setando o cache

                ViewBag.Mensagem = "Dados inseridos na memória cache";
            }

            else
            {
                pessoas = _cache.Get("ListaPessoas") as List<Pessoas>;
                ViewBag.Mensagem = "Dados pegos da memória cache";
            }

            return View(pessoas);
        }

        public IActionResult DadosSemMemoriaCache()
        {
            return View(_contexto.Pessoas.ToList());
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
