using HomeCourse.Models;
using HomeCourse.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeCourse.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ICarritoDeCompras carrito;
        private readonly ICurso obj;
        private readonly IInscripcion inscrip;
        private readonly IUsuario usu;
        public CarritoController(ICarritoDeCompras temporal, ICurso obj, IInscripcion inscrip, IUsuario usu)
        {
            carrito = temporal;
            this.obj = obj;
            this.inscrip = inscrip;
            this.usu = usu;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.Layout = "_LayoutUser";
                var carr= carrito.GetAllCarritoDeCompras();
                ViewData["Monto"] = MontoTotal();
                return View(carr);
            }
            else
            {
                ViewBag.Layout = "_Layout";
                var carr = carrito.GetAllCarritoDeCompras();
                ViewData["Monto"] = MontoTotal();
                return View(carr);
            }
            
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

        public IActionResult Comprar()
        {
            if (HttpContext.Session.GetString("UsuarioId")==null)
            {
                return RedirectToAction("InicioSesion","Iniciar");
            }
            else
            {
                var lst = new List<Inscripcion>();
                foreach (var cur in carrito.GetAllCarritoDeCompras())
                {
                    var ins = new Inscripcion();
                    ins.Id = inscrip.getIDCorrelativo();
                    ins.UsuarioId = HttpContext.Session.GetString("UsuarioId");
                    ins.CursoId = cur.CodCur;
                    ins.InsFecha = DateTime.Now.ToString("yyyy-MM-dd");
                    lst.Add(ins);
                }
                inscrip.Add(lst);

                carrito.DeleteAll();
                
                return RedirectToAction("Index");
            }
            
        }

        public decimal MontoTotal()
        {

            var lista = carrito.GetAllCarritoDeCompras().Count();
            decimal monto = lista*1000;
            return monto;
        }



    }
}
