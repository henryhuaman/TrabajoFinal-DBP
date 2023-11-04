using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ICurso obj;
        private readonly IProfesor prof;

        public PaginaController(ICurso obj, IProfesor prof)
        {
            this.obj = obj;
            this.prof = prof;
        }

        public IActionResult Index()
        {   
            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetAllCurso());
        }

        public IActionResult MostrarProfesores()
        {
            ViewBag.Categorias = obj.GetCategorias();
            return View(prof.GetAllProfesores());
        }

        public IActionResult MostrarCursos()
        {
            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetAllCurso());
        }
    }
}
