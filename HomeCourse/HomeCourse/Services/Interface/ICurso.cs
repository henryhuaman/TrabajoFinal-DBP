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
        List<string> GetCategorias();
        IEnumerable<Curso> GetCursosbyProfe(string id);
        List<Curso> GetCursoPorCategoria(string categoria); 

        
    }
}
