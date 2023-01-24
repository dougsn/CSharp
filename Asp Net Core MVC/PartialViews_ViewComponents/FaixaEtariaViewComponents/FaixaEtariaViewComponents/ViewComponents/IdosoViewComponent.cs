using FaixaEtariaViewComponents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaixaEtariaViewComponents.ViewComponents
{
    public class IdosoViewComponent : ViewComponent
    {
        private readonly PessoaContexto _pessoaContexto;

        public IdosoViewComponent(PessoaContexto pessoaContexto)
        {
            _pessoaContexto = pessoaContexto;
        }

        // Fazendo a lógica para filtrar as pessoas por determinada idade.

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _pessoaContexto.Pessoas.Where(x => x.Idade > 60).ToListAsync());
        }

    }
}
