using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICliente client;
        private readonly ICurso course;
        public ClienteController(ICliente cli, ICurso cur)
        {
            this.client = cli;
            this.course = cur;
        }
        public IActionResult Index()
        {
            var opciones = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Opción 1" },
            new SelectListItem { Value = "2", Text = "Opción 2" },
            new SelectListItem { Value = "3", Text = "Opción 3" }
        };

            // Crear un SelectList
            SelectList selectList = new SelectList(opciones, "Value", "Text");

            ViewBag.Opciones = selectList;

            ViewBag.Categorias = course.GetCategorias();
            return View(course.GetAllCurso());
        }
    }
}
