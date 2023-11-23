using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class AdministradorController : Controller
    {
        public readonly IUsuario users;
        public readonly IProfesor teachers;
        public readonly IAdministrador admins;
        public AdministradorController(IUsuario usuario, IProfesor profesor, IAdministrador administrador)
        {
            this.users = usuario;
            this.teachers = profesor;
            this.admins = administrador;
        } 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                var identifi = HttpContext.Session.GetString("AdminId");
                var control = admins.getAdministradorbyId(identifi);
                return View(control);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Registro_Profesores()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                var info = teachers.GetAllProfesores();
                return View(info);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Delete_Profesor(String id)
        {
            teachers.deleteProfesorDataById(id);
            return RedirectToAction("Registro_Profesores","Administrador");
        }
        public IActionResult Creation_Profesor()
        {
            return View();
        }
        public IActionResult Grabar_Profesor(Profesor p1)
        {
            String cant = teachers.GetAllProfesores().Last().Id;
            int quant = 0;
            if (cant.Length > 2 && int.TryParse(cant.Substring(2), out int parsedValue))
            {
                quant = parsedValue;
            }
            quant = quant + 1;
            string formattedNumber = quant.ToString("D3");
            p1.Id = "PR" + formattedNumber;
            teachers.addNew(p1);
            return RedirectToAction("Registro_Profesores", "Administrador");

        }
        public IActionResult Registro_Usuarios()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                var info = users.GetAllUsuarios();
                return View(info);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Delete_Usuario(String id)
        {
            users.deleteUsuarioDataById(id);
            return RedirectToAction("Regsitro_Usuarios", "Administrador");
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Pagina");
        }
    }
}
