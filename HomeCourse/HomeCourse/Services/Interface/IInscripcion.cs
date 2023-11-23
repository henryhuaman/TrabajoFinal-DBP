using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IInscripcion
    {
        IEnumerable<Inscripcion> GetAllInscripciones();
        void Delete(String id);
        void Add(Inscripcion listinsc);
        Inscripcion GetInscripcion(string id, string idUsu);
        String getIDCorrelativo();
        List<Relacion> getRelacion(string id);
    }
}
