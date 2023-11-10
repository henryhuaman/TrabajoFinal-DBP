using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeCourse.Controllers
{
    public class IniciarController : Controller
    {
        private readonly IProfesor Profe;
        private readonly IUsuario client;

        public IniciarController(IProfesor pro, IUsuario cle)
        {
            this.Profe = pro;
            this.client = cle;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InicioSesion()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult Verification(string email, string password)
        {
            if (Profe.ProfesorExistsbyCorreo(email))
            {
                if (Profe.passwordMatchvyEmail(email, password))
                {
                    HttpContext.Session.SetString("ProfesorId", Profe.getProfesorbyCorreo(email).Id);
                    return RedirectToAction("Index", "Profesor");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Iniciar");
                }
            }
            else if (client.UsuarioExistsbyCorreo(email))
            {
                if (client.passwordMatchvyEmail(email, password))
                {
                    HttpContext.Session.SetString("UsuarioId", client.getUsuariobyCorreo(email).Id);
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Iniciar");
                }
            }
            else
            {
                return RedirectToAction("InicioSesion", "Iniciar");
            }
        }

    }
}
