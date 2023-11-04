using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface ICurso
    {
        IEnumerable<Curso> GetAllCurso();
        void Add(Curso curso);
        void Update(Curso curso);
        void Delete(string id);

        Curso GetCurso(string id);

        List<Curso> GetCursoPorCategoria(string categoria);
        List<string> GetCategorias();
    }
}
