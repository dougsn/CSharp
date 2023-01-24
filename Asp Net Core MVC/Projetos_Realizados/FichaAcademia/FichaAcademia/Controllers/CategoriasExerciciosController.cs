using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FichaAcademia.AcessoDados;
using FichaAcademia.Dominio.Models;
using FichaAcademia.AcessoDados.Interfaces;

namespace FichaAcademia.Controllers
{
    public class CategoriasExerciciosController : Controller
    {
        private readonly ICategoriaExercicioRepositorio _categoriaExercicioRepositorio;

        public CategoriasExerciciosController(ICategoriaExercicioRepositorio categoriaExercicioRepositorio)
        {
            _categoriaExercicioRepositorio = categoriaExercicioRepositorio;
        }

        // GET: CategoriasExercicios
        public async Task<IActionResult> Index()
        {
            return  View(await _categoriaExercicioRepositorio.PegarTodos().ToListAsync());
        }
         


        // GET: CategoriasExercicios/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepositorio.Inserir(categoriaExercicio);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        // GET: CategoriasExercicios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaExercicio = await _categoriaExercicioRepositorio.PegarPeloId(id);
            if (categoriaExercicio == null)
            {
                return NotFound();
            }
            return View(categoriaExercicio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (id != categoriaExercicio.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _categoriaExercicioRepositorio.Atualizar(categoriaExercicio);


                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

       

        // POST: CategoriasExercicios/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaExercicioRepositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

      

        public async Task<JsonResult> CategoriaExiste(string nome, int CategoriaExercicioId)
        {
            if (CategoriaExercicioId == 0)
            {
                if (await _categoriaExercicioRepositorio.CategoriaExiste(nome))
                {
                    return Json("Categoria já existe");
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                if(await _categoriaExercicioRepositorio.CategoriaExiste(nome, CategoriaExercicioId))
                {
                    return Json("Categoria já existe");
                }
                else
                {
                    return Json(true);
                }
            }
        }

    }
}
