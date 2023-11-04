using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ICarritoDeCompras carrito;
        private readonly ICurso obj;
        public CarritoController(ICarritoDeCompras temporal, ICurso obj)
        {
            carrito = temporal;
            this.obj = obj;
        }


        public IActionResult Index()
        {

            ViewBag.Categorias = obj.GetCategorias();
            ViewData["Monto"] = MontoTotal();
            return View(carrito.GetAllCarritoDeCompras());
        }

        public IActionResult Agregar(String id)
        {
            var cur = obj.GetCurso(id);
            var car = new CarritoDeCompras();
            car.NomCur = cur.Nombre;
            car.CodCur = cur.Id;
            car.CateCur = cur.Categoria;
            carrito.Add(car);
            return RedirectToAction("Index");
        }


        public decimal MontoTotal()
        {

            var lista = carrito.GetAllCarritoDeCompras().Count();
            decimal monto = lista*1000;
            return monto;
        }
    }
}
