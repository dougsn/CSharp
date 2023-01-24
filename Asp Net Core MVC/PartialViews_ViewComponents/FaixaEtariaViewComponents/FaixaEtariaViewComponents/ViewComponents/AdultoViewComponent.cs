using FaixaEtariaViewComponents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FaixaEtariaViewComponents.ViewComponents
{
    public class AdultoViewComponent : ViewComponent
    {
        private readonly PessoaContexto _pessoaContexto;

        public AdultoViewComponent(PessoaContexto pessoaContexto)
        {
            _pessoaContexto = pessoaContexto;
        }

        // Criando a regra para filtrar as pessoas pela idade
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _pessoaContexto.Pessoas.Where(x => x.Idade >= 18 && x.Idade < 60).ToListAsync());
        }

    }
}
