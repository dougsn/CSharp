﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MontagemCr.Models;

namespace MontagemCr.Controllers
{
    public class FormacoesAcademicasController : Controller
    {
        private readonly Contexto _context;

        public FormacoesAcademicasController(Contexto context)
        {
            _context = context;
        }

        

        // GET: FormacoesAcademicas/Create
        public IActionResult Create(int id)
        {
            FormacaoAcademica formacao = new FormacaoAcademica();
            formacao.CurriculoId = id;            
            ViewData["TipoCursoId"] = new SelectList(_context.TiposCursos, "TipoCursoId", "Tipo");
            return View(formacao);
        }

        // POST: FormacoesAcademicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormacaoAcademicaId,TipoCursoId,Instituicao,AnoInicio,AnoFim,NomeCurso,CurriculoId")] FormacaoAcademica formacaoAcademica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacaoAcademica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Curriculos", new { id = formacaoAcademica.CurriculoId });
            }
            
            ViewData["TipoCursoId"] = new SelectList(_context.TiposCursos, "TipoCursoId", "Tipo", formacaoAcademica.TipoCursoId);
            return View(formacaoAcademica);
        }

        // GET: FormacoesAcademicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoAcademica = await _context.FormacoesAcademicas.FindAsync(id);
            if (formacaoAcademica == null)
            {
                return NotFound();
            }
            ViewData["TipoCursoId"] = new SelectList(_context.TiposCursos, "TipoCursoId", "Tipo", formacaoAcademica.TipoCursoId);
            return View(formacaoAcademica);
        }

        // POST: FormacoesAcademicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormacaoAcademicaId,TipoCursoId,Instituicao,AnoInicio,AnoFim,NomeCurso,CurriculoId")] FormacaoAcademica formacaoAcademica)
        {
            if (id != formacaoAcademica.FormacaoAcademicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacaoAcademica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoAcademicaExists(formacaoAcademica.FormacaoAcademicaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculos", new { id = formacaoAcademica.CurriculoId });
            }
            ViewData["TipoCursoId"] = new SelectList(_context.TiposCursos, "TipoCursoId", "Tipo", formacaoAcademica.TipoCursoId);
            return View(formacaoAcademica);
        }

        

        // POST: FormacoesAcademicas/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var formacaoAcademica = await _context.FormacoesAcademicas.FindAsync(id);
            _context.FormacoesAcademicas.Remove(formacaoAcademica);
            await _context.SaveChangesAsync();
            return Json("Formação acadêmica excluída");
        }

        private bool FormacaoAcademicaExists(int id)
        {
            return _context.FormacoesAcademicas.Any(e => e.FormacaoAcademicaId == id);
        }
    }
}
