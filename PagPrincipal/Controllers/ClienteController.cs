using Microsoft.AspNetCore.Mvc;

namespace PagPrincipal.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
