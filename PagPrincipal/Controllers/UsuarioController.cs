using Microsoft.AspNetCore.Mvc;

namespace PagPrincipal.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
