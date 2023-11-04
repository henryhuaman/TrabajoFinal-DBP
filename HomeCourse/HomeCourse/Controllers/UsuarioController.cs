using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuario usu;
        private readonly ICurso obj;

        public UsuarioController(IUsuario usu, ICurso obj)
        {
            this.usu = usu;
            this.obj = obj;

        }
        public IActionResult Index()
        {
            
            return View();
        }
        [Route("inicio/verPerfil")]
        public IActionResult VerPerfil()
        {
            var usuarioId = HttpContext.Session.GetString("UsuarioId");
            var usuario = usu.getUsuariobyCod(usuarioId);

            return View(usuario);
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Pagina");
        }
        [Route("inicio/Editar")]
        public IActionResult Edit()
        {
            var usuarioId = HttpContext.Session.GetString("UsuarioId");
            var usuario = usu.getUsuariobyCod(usuarioId);
            return View(usuario);
        }
        public IActionResult EditDetails(Usuario usuario)
        {
            usu.Update(usuario);
            HttpContext.Session.SetString("UsuarioId", usuario.Id);

            return RedirectToAction("VerPerfil");
        }
    }
}
