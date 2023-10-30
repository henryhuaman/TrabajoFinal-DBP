using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagPrincipal.Models;
using PagPrincipal.Services.Interface;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IProfesores Profe;
        private readonly ICliente client;
        private readonly ICurso obj;
        public UsuarioController (IProfesores pro, ICliente cle, ICurso crs)
        {
            this.Profe = pro;
            this.client = cle;
            this.obj = crs;
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

            var viewModel = new IndexViewModel
            {
                Courses = obj.GetAllCurso(),
                Opciones = selectList,
                Categorias = obj.GetCategorias()
            };

            return View(viewModel);
        }
        public IActionResult Verification(string email, string password) {
            if (Profe.ProfesorExistsbyCorreo(email))
            {
                if (Profe.passwordMatchvyEmail(email, password))
                {
                    return RedirectToAction("Index", "Profesores", new { email, password });
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Usuario");
                }
            } else if (client.ClienteExistsbyCorreo(email))
            {
                if (client.passwordMatchvyEmail(email, password))
                {
                    return RedirectToAction("Index","Cliente", new { email, password });
                }
                else
                {
                    return RedirectToAction("InicioSesion","Usuario");
                }
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
    }
}
