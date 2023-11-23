using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class ProfesorController : Controller
    {
        public readonly IUsuario users;
        public readonly IProfesor teachers;
        public readonly ICurso courses; 
        public ProfesorController(ICurso C, IProfesor P, IUsuario U) 
        { 
            this.users = U;
            this.teachers = P;
            this.courses = C;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var identifi = HttpContext.Session.GetString("ProfesorId");
                var control = teachers.getProfesorbyID(identifi);
                return View(control);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Perfil()
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var identifi = HttpContext.Session.GetString("ProfesorId");
                var control = teachers.getProfesorbyID(identifi);
                return View(control);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Edicion()
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var identifi = HttpContext.Session.GetString("ProfesorId");
                var control = teachers.getProfesorbyID(identifi);
                return View(control);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Grabar(Profesor profe)
        {
            teachers.actualizar(profe);
            return RedirectToAction("Perfil","Profesor");
        }
        public IActionResult Materias()
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var identifi = HttpContext.Session.GetString("ProfesorId");
                var materias = courses.GetCursosbyProfe(identifi);
                return View(materias);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Alumnos_Materia(String id)
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var alumnos = users.getUsuariosbyCurso(id);
                return View(alumnos);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Editar_Materia(String id)
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                var materia = courses.GetCurso(id);
                return View(materia);
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Cambios_Materia(Curso c)
        {
            courses.Update(c);
            return RedirectToAction("Materias", "Profesor");
        }
        public IActionResult Eliminar_Materia(String id)
        {
            courses.Delete(id);
            return RedirectToAction("Materias", "Profesor");
        }
        public IActionResult Creation_Curso()
        {
            if (HttpContext.Session.GetString("ProfesorId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Pagina");
            }
        }
        public IActionResult Grabar_Curso(Curso c)
        {
            String cant = courses.GetAllCurso().Last().Id;
            int quant = 0;
            if (cant.Length > 2 && int.TryParse(cant.Substring(2), out int parsedValue))
            {
                quant = parsedValue;
            }
            quant = quant + 1;
            string formattedNumber = quant.ToString("D3");
            c.Id = "CR" + formattedNumber;
            courses.Add(c);
            return RedirectToAction("Materias", "Profesor");

        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Pagina");
        }
    }
}
