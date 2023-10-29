using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagPrincipal.Services.Interface;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class UsuarioController : Controller
    {
        private CursoRepository obj = new CursoRepository();
        private readonly IProfesores Profe;
        public UsuarioController (IProfesores pro)
        {
            this.Profe = pro;
        }
        public IActionResult Index()
        {
            ViewBag.Categorias = obj.GetCategorias();
            ViewBag.Cursos= obj.GetAllCurso();
            return View();
        }
        public IActionResult InicioSesion() {
            
            var opciones = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Opción 1" },
            new SelectListItem { Value = "2", Text = "Opción 2" },
            new SelectListItem { Value = "3", Text = "Opción 3" }
        };

            // Crear un SelectList
            SelectList selectList = new SelectList(opciones, "Value", "Text");

            ViewBag.Opciones = selectList;

            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetAllCurso());
        }
        public IActionResult Verification(string email, string password) {
            if (Profe.ProfesorExistsbyCorreo(email))
            {
                if (Profe.passwordMatchvyEmail(email, password))
                {
                    return RedirectToAction("Index", "Profesores");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Usuario");
                }
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
    }
}
