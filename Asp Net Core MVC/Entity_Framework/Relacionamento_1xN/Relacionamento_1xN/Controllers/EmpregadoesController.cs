using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Relacionamento_1xN.Models;

namespace Relacionamento_1xN.Controllers
{
    public class EmpregadoesController : Controller
    {
        private readonly Contexto _context;

        public EmpregadoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Empregadoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Empregados.Include(e => e.Trabalho);
            return View(await contexto.ToListAsync());
        }

        // GET: Empregadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados
                .Include(e => e.Trabalho)
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }

        // GET: Empregadoes/Create
        public IActionResult Create()
        {
            ViewData["TrabalhoId"] = new SelectList(_context.Set<Trabalho>(), "TrabalhoId", "Nome");
            return View();
        }

        // POST: Empregadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpregadoId,Nome,Idade,CPF,TrabalhoId")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empregado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrabalhoId"] = new SelectList(_context.Set<Trabalho>(), "TrabalhoId", "Nome", empregado.TrabalhoId);
            return View(empregado);
        }

        // GET: Empregadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados.FindAsync(id);
            if (empregado == null)
            {
                return NotFound();
            }
            ViewData["TrabalhoId"] = new SelectList(_context.Set<Trabalho>(), "TrabalhoId", "TrabalhoId", empregado.TrabalhoId);
            return View(empregado);
        }

        // POST: Empregadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpregadoId,Nome,Idade,CPF,TrabalhoId")] Empregado empregado)
        {
            if (id != empregado.EmpregadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadoExists(empregado.EmpregadoId))
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
            ViewData["TrabalhoId"] = new SelectList(_context.Set<Trabalho>(), "TrabalhoId", "TrabalhoId", empregado.TrabalhoId);
            return View(empregado);
        }

        // GET: Empregadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados
                .Include(e => e.Trabalho)
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }

        // POST: Empregadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);
            _context.Empregados.Remove(empregado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregados.Any(e => e.EmpregadoId == id);
        }
    }
}
