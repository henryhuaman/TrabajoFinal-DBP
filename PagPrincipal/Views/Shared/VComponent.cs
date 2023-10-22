using Microsoft.AspNetCore.Mvc;
using PagPrincipal.Models;
using PagPrincipal.Services.Repository;

namespace PagPrincipal.Views.Shared
{
    public class VComponent : ViewComponent
    {
        private CursoRepository obj = new CursoRepository();
        public IViewComponentResult Invoke()
        {
            var datos = ObtenerDatos();  // Aquí obtienes tus datos, por ejemplo, desde una base de datos o cualquier fuente

            return View(datos);
        }

        private IEnumerable<TbCurso> ObtenerDatos()
        {
            return obj.GetAllCurso();  // Aquí podrías obtener tus datos de donde necesites
        }
    }
}
