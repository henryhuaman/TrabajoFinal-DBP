using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Models;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class PaginaController : Controller
    {
        private CursoRepository obj = new CursoRepository();
        public IActionResult Index()
        {
            return View(obj.GetAllCurso());
        }
    }
}
