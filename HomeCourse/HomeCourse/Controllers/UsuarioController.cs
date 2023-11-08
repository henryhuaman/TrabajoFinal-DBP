using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuario usu;
        private readonly ICurso obj;
        private readonly IInscripcion ins;

        public UsuarioController(IUsuario usu, ICurso obj, IInscripcion ins)
        {
            this.usu = usu;
            this.obj = obj;
            this.ins = ins;

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
            
        }
        [Route("inicio/verPerfil")]
        public IActionResult VerPerfil()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.Layout = "_LayoutUser";
                var usuarioId = HttpContext.Session.GetString("UsuarioId");
                var usuario = usu.getUsuariobyCod(usuarioId);

                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index","Pagina");
            }
            
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Pagina");
        }
        [Route("inicio/Editar")]
        public IActionResult Edit()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                var usuarioId = HttpContext.Session.GetString("UsuarioId");
                var usuario = usu.getUsuariobyCod(usuarioId);
                ViewBag.Layout = "_LayoutUser";
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
                
        }
        public IActionResult EditDetails(Usuario usuario)
        {
            usu.Update(usuario);
            HttpContext.Session.SetString("UsuarioId", usuario.Id);

            return RedirectToAction("VerPerfil");
        }

        public IActionResult VerSusCursos()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.Categorias = obj.GetCategorias();
                return View(ins.getRelacion(HttpContext.Session.GetString("UsuarioId")));
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
            
        }
    }
}
