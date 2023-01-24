using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesquisaCripto.Models;

namespace PesquisaCripto.Controllers
{
    public class MoedasController : Controller
    {
        private readonly MoedasContexto _context;

        public MoedasController(MoedasContexto context)
        {
            _context = context;
        }

        // GET: Moedas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moedas.ToListAsync());
        }

        public async Task<IActionResult> EscolhadeMoedas(List<Moedas> moedas)
        {
            foreach (var item in moedas)
            {
                if (item.CheckBoxMarcado == true) // Se o checkbox estiver marcado, faça isso
                {
                    Moedas moeda = await _context.Moedas.FirstAsync(x => x.MoedasId == item.MoedasId);
                    moeda.Quantidade = moeda.Quantidade + 1;
                    _context.Update(moeda);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // Método responsável por retornar os dados em JSON para a criação do gráfico
        public JsonResult DadosGrafico()
        {
            return Json(_context.Moedas.Select(x => new { x.Nome, x.Quantidade }));
        }

        // GET: Moedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moedas/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoedasId,Nome,Quantidade")] Moedas moedas)
        {
            if (ModelState.IsValid)
            {
                moedas.Quantidade = 0;
                _context.Add(moedas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moedas);
        }
        
    }
}
