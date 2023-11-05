using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class CarritoDeComprasRepository : ICarritoDeCompras
    {   
        private List<CarritoDeCompras> _compras = new List<CarritoDeCompras>();
        public void Add(CarritoDeCompras curso)
        {
            _compras.Add(curso);
        }

        public void Delete(string id)
        {   
            _compras.RemoveAll(c => c.CodCur == id);
        }

        public void DeleteAll()
        {
            _compras.Clear();
        }

        public IEnumerable<CarritoDeCompras> GetAllCarritoDeCompras()
        {
            return _compras ;
        }

        public void Update(CarritoDeCompras curso)
        {
            throw new NotImplementedException();
        }
    }
}
