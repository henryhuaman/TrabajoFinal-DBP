using Microsoft.AspNetCore.Mvc.Rendering;

namespace PagPrincipal.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TbCurso> Courses { get; set; }
        public SelectList Opciones { get; set; }
        public List<String> Categorias { get; set; }
        public TbProfesore PROFE { get; set; }
        public IEnumerable<TbCurso> cursodePROFE { get; set; }
    }
}
