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
    public class ExperienciasProfissionaisController : Controller
    {
        private readonly Contexto _context;

        public ExperienciasProfissionaisController(Contexto context)
        {
            _context = context;
        }

      

        // GET: ExperienciasProfissionais/Create
        public IActionResult Create(int id)
        {
            ExperienciaProfissional experiencia = new ExperienciaProfissional();
            experiencia.CurriculoId = id;            
            return View(experiencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienciaProfissionalId,NomeEmpresa,Cargo,AnoInicio,AnoFim,DescricaoAtividades,CurriculoId")] ExperienciaProfissional experienciaProfissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienciaProfissional);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Curriculos", new { id = experienciaProfissional.CurriculoId });
            }
            
            return View(experienciaProfissional);
        }

        // GET: ExperienciasProfissionais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaProfissional = await _context.ExperienciasProfissionais.FindAsync(id);
            if (experienciaProfissional == null)
            {
                return NotFound();
            }
            return View(experienciaProfissional);
        }

        // POST: ExperienciasProfissionais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienciaProfissionalId,NomeEmpresa,Cargo,AnoInicio,AnoFim,DescricaoAtividades,CurriculoId")] ExperienciaProfissional experienciaProfissional)
        {
            if (id != experienciaProfissional.ExperienciaProfissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienciaProfissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaProfissionalExists(experienciaProfissional.ExperienciaProfissionalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculos", new { id = experienciaProfissional.CurriculoId });
            }
            return View(experienciaProfissional);
        }


        // POST: ExperienciasProfissionais/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var experienciaProfissional = await _context.ExperienciasProfissionais.FindAsync(id);
            _context.ExperienciasProfissionais.Remove(experienciaProfissional);
            await _context.SaveChangesAsync();
            return Json("Experiência excluída com sucesso");
        }

        private bool ExperienciaProfissionalExists(int id)
        {
            return _context.ExperienciasProfissionais.Any(e => e.ExperienciaProfissionalId == id);
        }
    }
}
