using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Relacionamento_NxN.Models;

namespace Relacionamento_NxN.Controllers
{
    public class EmpregadoTrabalhosController : Controller
    {
        private readonly Contexto _context;

        public EmpregadoTrabalhosController(Contexto context)
        {
            _context = context;
        }

        // GET: EmpregadoTrabalhos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EmpregadoTrabalhos.Include(e => e.Empregado).Include(e => e.Trabalho);
            return View(await contexto.ToListAsync());
        }

        // GET: EmpregadoTrabalhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregadoTrabalho = await _context.EmpregadoTrabalhos
                .Include(e => e.Empregado)
                .Include(e => e.Trabalho)
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregadoTrabalho == null)
            {
                return NotFound();
            }

            return View(empregadoTrabalho);
        }

        // GET: EmpregadoTrabalhos/Create
        public IActionResult Create()
        {
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "EmpregadoId", "Nome");
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "TrabalhoId", "Nome");
            return View();
        }

        // POST: EmpregadoTrabalhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpregadoId,TrabalhoId,CargaHoraria")] EmpregadoTrabalho empregadoTrabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empregadoTrabalho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "EmpregadoId", "Nome", empregadoTrabalho.EmpregadoId);
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "TrabalhoId", "Nome", empregadoTrabalho.TrabalhoId);
            return View(empregadoTrabalho);
        }

        // GET: EmpregadoTrabalhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregadoTrabalho = await _context.EmpregadoTrabalhos.FindAsync(id);
            if (empregadoTrabalho == null)
            {
                return NotFound();
            }
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "EmpregadoId", "EmpregadoId", empregadoTrabalho.EmpregadoId);
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "TrabalhoId", "TrabalhoId", empregadoTrabalho.TrabalhoId);
            return View(empregadoTrabalho);
        }

        // POST: EmpregadoTrabalhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpregadoId,TrabalhoId,CargaHoraria")] EmpregadoTrabalho empregadoTrabalho)
        {
            if (id != empregadoTrabalho.EmpregadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregadoTrabalho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadoTrabalhoExists(empregadoTrabalho.EmpregadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "EmpregadoId", "EmpregadoId", empregadoTrabalho.EmpregadoId);
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "TrabalhoId", "TrabalhoId", empregadoTrabalho.TrabalhoId);
            return View(empregadoTrabalho);
        }

        // GET: EmpregadoTrabalhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregadoTrabalho = await _context.EmpregadoTrabalhos
                .Include(e => e.Empregado)
                .Include(e => e.Trabalho)
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregadoTrabalho == null)
            {
                return NotFound();
            }

            return View(empregadoTrabalho);
        }

        // POST: EmpregadoTrabalhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregadoTrabalho = await _context.EmpregadoTrabalhos.FindAsync(id);
            _context.EmpregadoTrabalhos.Remove(empregadoTrabalho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadoTrabalhoExists(int id)
        {
            return _context.EmpregadoTrabalhos.Any(e => e.EmpregadoId == id);
        }
    }
}
