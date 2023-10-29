using PagPrincipal.Models;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Services.Repository
{
    public class ProfesoresRepository : IProfesores
    {
        private BdWeb database = new BdWeb();
        public IEnumerable<TbProfesore> getAllProfesores()
        {
            throw new NotImplementedException();
        }

        public TbProfesore getProfesorbyCod(string cod)
        {
            throw new NotImplementedException();
        }

        public TbProfesore getProfesorbyCorreo(string correo)
        {
            return (from matched in database.TbProfesores where matched.CorPro == correo select matched).Single();
        }

        public TbProfesore getProfesorbyDNI(string dni)
        {
            throw new NotImplementedException();
        }

        public TbProfesore getProfesorbyName(string name)
        {
            throw new NotImplementedException();
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingProfesor = (from profesor in database.TbProfesores where profesor.CorPro == correo && profesor.ContraPro == password select profesor).Any();

            return matchingProfesor;
        }

        public bool ProfesorExistsbyCorreo(string correo)
        {
            var exists = database.TbProfesores.Any(profesor => profesor.CorPro == correo);
            return exists;
        }
    }
}
