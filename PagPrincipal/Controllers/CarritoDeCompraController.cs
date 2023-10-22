using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Models;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class CarritoDeCompraController : Controller
    {   
        CursoRepository obj = new CursoRepository();

        public IActionResult Index()
        {
            ViewBag.Categorias = obj.GetCategorias();
            return View();
        }
    }
}
