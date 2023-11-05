using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface ICarritoDeCompras
    {
        IEnumerable<CarritoDeCompras> GetAllCarritoDeCompras();
        void Add(CarritoDeCompras curso);
        void Update(CarritoDeCompras curso);
        void Delete(string id);
        void DeleteAll();

    }
}
