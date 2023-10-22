using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Models;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class CursoController : Controller
    {
        private CursoRepository obj = new CursoRepository();
        public IActionResult Index()
        {
            ViewBag.Categorias = obj.GetCategorias();
            ViewBag.Cursos=obj.GetAllCurso();
            return View();
        }
        public IActionResult Listar()
        {
            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetAllCurso());
        }

        public IActionResult Grabar(TbCurso curso)
        {
            ViewBag.Categorias = obj.GetCategorias();
            obj.Add(curso);
            return RedirectToAction("Listar");
        }
        [Route("Curso/Edit/{cod}")]
        public IActionResult Edit(string cod)
        {
            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetCurso(cod));
        }
        [Route("Curso/Delete/{cod}")]
        public IActionResult Delete(string cod)
        {
            ViewBag.Categorias = obj.GetCategorias();
            obj.Delete(cod);
            return RedirectToAction("Listar");
        }

        public IActionResult EditDetails(TbCurso tbcurso)
        {
            ViewBag.Categorias = obj.GetCategorias();
            obj.Update(tbcurso);
            return RedirectToAction("Listar");

        }

    }
}
