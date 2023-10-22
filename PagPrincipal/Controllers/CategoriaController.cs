using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class CategoriaController : Controller
    {
        private CursoRepository obj = new CursoRepository();
        public IActionResult Index(string id)
        {

            ViewBag.Categorias = obj.GetCategorias();
            ViewData["Categoria"]=id;
            return View(obj.GetCursoPorCategoria(id));
        }
    }
}
