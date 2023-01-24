using Microsoft.AspNetCore.Mvc;

namespace AppModelo.Areas.Vendas.Controllers
{
    [Area("Vendas")]
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        [Route("vendas")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
