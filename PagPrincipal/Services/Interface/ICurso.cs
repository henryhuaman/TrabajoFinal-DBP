using PagPrincipal.Models;
    
namespace PagPrincipal.Services.Interface
{
    public interface ICurso
    {
        IEnumerable<TbCurso> GetAllCurso();
        void Add(TbCurso curso);
        void Update(TbCurso curso);
        void Delete(string id);
        TbCurso GetCurso(string id);
        List<string> GetCategorias();
    }
}
