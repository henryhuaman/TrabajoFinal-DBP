using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagPrincipal.Models;
using PagPrincipal.Services.Interface;
using PagPrincipal.Services.Repository;
using System.Collections;

namespace PagPrincipal.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ICurso curs;
        public PaginaController(ICurso courese) {
            this.curs = courese;
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

            ViewBag.Categorias = curs.GetCategorias();

            var viewModel = new IndexViewModel
            {
                Courses = curs.GetAllCurso(),
                Opciones = selectList,
                Categorias = curs.GetCategorias()
            };

            return View(viewModel);
        }
    }
}
