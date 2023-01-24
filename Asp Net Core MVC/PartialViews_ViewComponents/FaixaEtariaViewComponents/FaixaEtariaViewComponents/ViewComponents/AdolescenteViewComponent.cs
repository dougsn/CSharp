using Microsoft.AspNetCore.Mvc;
using FaixaEtariaViewComponents.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FaixaEtariaViewComponents.ViewComponents
{
    public class AdolescenteViewComponent : ViewComponent
    {
        private readonly PessoaContexto _pessoaContext;

        public AdolescenteViewComponent(PessoaContexto pessoaContexto)
        {
            _pessoaContext = pessoaContexto;
        }

        // Construindo a lógica para amostrar apenas as pessoas que possuem idade menos que 18
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _pessoaContext.Pessoas.Where(x => x.Idade < 18).ToListAsync());
        }

    }
}
