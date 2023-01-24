using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize] // Para acessar esse controlado, tem que está logado.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous] // Qualquer 1 pode entrar
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Gestor")] // Essa forma, configuramos a autorização.
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")] // Essa forma, configuramos a autorização de forma básica da claim.
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")] // Essa forma, configuramos a autorização de forma que dê para colocar mais autorizações na tabela do Identity
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contato nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;                 
            }
            else if (id == 404)
            {

                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            } else if(id == 403)
            {

                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Erro", modelErro);
        }
    }
}