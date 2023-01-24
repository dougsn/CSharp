using AppModelo.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppModelo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository) // Injetando dependencia
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {

            var pedido = _pedidoRepository.ObterPedido();


            return View();
        }
    }
}
