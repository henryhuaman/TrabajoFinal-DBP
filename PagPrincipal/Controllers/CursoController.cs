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
            return View();
        }
        public IActionResult Listar()
        {
            return View(obj.GetAllCurso());
        }

        public IActionResult Grabar(TbCurso curso)
        {
            obj.Add(curso);
            return RedirectToAction("Listar");
        }
        [Route("Curso/Edit/{cod}")]
        public IActionResult Edit(string cod)
        {

            return View(obj.GetCurso(cod));
        }
        [Route("Curso/Delete/{cod}")]
        public IActionResult Delete(string cod)
        {
            obj.Delete(cod);
            return RedirectToAction("Listar");
        }

        public IActionResult EditDetails(TbCurso tbcurso)
        {
            obj.Update(tbcurso);
            return RedirectToAction("Listar");

        }

    }
}
