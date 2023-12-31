﻿using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ICurso obj;
        private readonly IProfesor prof;

        public PaginaController(ICurso obj, IProfesor prof)
        {
            this.obj = obj;
            this.prof = prof;
        }

        public IActionResult Index()
        {
            return View(obj.GetAllCurso());
        }

        public IActionResult MostrarProfesores()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.Layout = "_LayoutUser";
            }
            else
            {
                ViewBag.Layout = "_Layout";
            }

            var group = new ProfYCur
            {
                profesors = prof.GetAllProfesores(),
                cursos = obj.GetAllCurso()
            };

            return View(group);
        }

        public IActionResult MostrarCursos()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.Layout = "_LayoutUser";
            }
            else
            {
                ViewBag.Layout = "_Layout";
            }
            ViewBag.Categorias = obj.GetCategorias();
            return View(obj.GetAllCurso());
        }

        
    }
}
