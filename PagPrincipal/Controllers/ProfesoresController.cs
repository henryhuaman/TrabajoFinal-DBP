using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagPrincipal.Models;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly ICurso course;
        private readonly IProfesores profe;
        public ProfesoresController(IProfesores prof, ICurso course)
        {
            this.profe = prof;
            this.course = course;
        }
        public IActionResult Index(string email, string password)
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

            var PROFE = profe.getProfesorbyCorreo(email);

            var viewModel = new IndexViewModel
            {
                Courses = course.GetAllCurso(),
                Opciones = selectList,
                Categorias = course.GetCategorias(),
                PROFE = profe.getProfesorbyCorreo(email),
                cursodePROFE = course.GetCursosbyProfe(PROFE)
            };

            

            return View(viewModel);
        }
        public IActionResult Index_Curso()
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

            var PROFE = TempData["PROFE"] as TbProfesore;

            var viewModel = new IndexViewModel
            {
                Courses = course.GetAllCurso(),
                Opciones = selectList,
                Categorias = course.GetCategorias(),
                PROFE = PROFE,
                cursodePROFE = course.GetCursosbyProfe(PROFE)

            };

            return View(viewModel);
        }
    }
}
