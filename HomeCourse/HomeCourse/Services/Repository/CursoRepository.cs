using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class CursoRepository : ICurso
    {
        private BdWeb bd = new BdWeb();

        public void Add(Curso curso)
        {
            try
            {
                bd.Cursos.Add(curso);//Insert into
                bd.SaveChanges();//actualizar la bd
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(string id)
        {
            var obj = (from tcurso in bd.Cursos
                       where tcurso.Id == id
                       select tcurso).Single();
            bd.Cursos.Remove(obj);
            bd.SaveChanges();
        }

        public IEnumerable<Curso> GetAllCurso()
        {
            return bd.Cursos;
        }

        public List<Curso> GetCursoPorCategoria(string categoria)
        {
            var obj = (from tcurso in bd.Cursos
                       where tcurso.Categoria == categoria
                       select tcurso).ToList();
            return obj;
        }


        public Curso GetCurso(string id)
        {
            var obj = (from tcurso in bd.Cursos
                       where tcurso.Id == id
                       select tcurso).Single();
            return obj;
        }

        public void Update(Curso cursoConDatosModificados)
        {
            var objModificado = (from tcurso in bd.Cursos
                                 where tcurso.Id == cursoConDatosModificados.Id
                                 select tcurso).FirstOrDefault();
            if (objModificado != null)
            {

                objModificado.Id = cursoConDatosModificados.Id;
                objModificado.Nombre = cursoConDatosModificados.Nombre;
                objModificado.Categoria = cursoConDatosModificados.Categoria;

                bd.SaveChanges();
            }
        }

        public List<string> GetCategorias()
        {
            var categorias = bd.Cursos.Select(alumno => alumno.Categoria).Distinct().ToList();
            return categorias;
        }

        public IEnumerable<Curso> GetCursosbyProfe(string id)
        {
            return (from matching in bd.Cursos where matching.ProfesorId == id select matching).ToList();
        }
    }
}
