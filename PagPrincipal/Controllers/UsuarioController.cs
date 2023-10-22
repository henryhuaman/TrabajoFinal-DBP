﻿using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Controllers
{
    public class UsuarioController : Controller
    {
        private CursoRepository obj = new CursoRepository();
        public IActionResult Index()
        {
            ViewBag.Categorias = obj.GetCategorias();
            ViewBag.Cursos= obj.GetAllCurso();
            return View();
        }
    }
}
