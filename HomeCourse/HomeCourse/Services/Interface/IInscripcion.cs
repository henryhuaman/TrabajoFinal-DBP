using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IInscripcion
    {
        IEnumerable<Inscripcion> GetAllInscripciones();

        void Delete(String id);
        void Add(List<Inscripcion> listinsc);
        IEnumerable<Inscripcion> GetInscripcion(string id);
        String getIDCorrelativo();
    }
}
