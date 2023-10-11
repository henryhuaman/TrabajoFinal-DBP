using PagPrincipal.Models;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Services.Repository
{
    public class CursoRepository : ICurso
    {
        private BdCursos bd = new BdCursos();

        public void Add(TbCurso curso)
        {
            try
            {
                bd.TbCursos.Add(curso);//Insert into
                bd.SaveChanges();//actualizar la bd
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(string id)
        {
            var obj = (from tcurso in bd.TbCursos
                       where tcurso.CodCur == id
                       select tcurso).Single();
            bd.TbCursos.Remove(obj);
            bd.SaveChanges();
        }

        public IEnumerable<TbCurso> GetAllCurso()
        {
            return bd.TbCursos;
        }

        public TbCurso GetCurso(string id)
        {
            var obj = (from tcurso in bd.TbCursos
                       where tcurso.CodCur == id
                       select tcurso).Single();
            return obj;
        }

        public void Update(TbCurso cursoConDatosModificados)
        {
            var objModificado = (from tcurso in bd.TbCursos
                                 where tcurso.CodCur == cursoConDatosModificados.CodCur
                                 select tcurso).FirstOrDefault();
            if (objModificado != null)
            {

                objModificado.CodCur = cursoConDatosModificados.CodCur;
                objModificado.NomCur = cursoConDatosModificados.NomCur;
                objModificado.CateCur = cursoConDatosModificados.CateCur;
                objModificado.TamCur = cursoConDatosModificados.TamCur;

                bd.SaveChanges();
            }
        }
    }
}
