using PagPrincipal.Models;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Services.Repository
{
    public class ProfesoresRepository : IProfesores
    {
        private BdWeb database = new BdWeb();
        public IEnumerable<TbProfesore> getAllProfesores()
        {
            return database.TbProfesores;
        }

        public TbProfesore getProfesorbyCod(string cod)
        {
            return (from matching in database.TbProfesores where matching.CodPro == cod select matching).Single();
        }

        public TbProfesore getProfesorbyCorreo(string correo)
        {
            return (from matched in database.TbProfesores where matched.CorPro == correo select matched).Single();
        }

        public TbProfesore getProfesorbyDNI(string dni)
        {
            return (from matching in database.TbProfesores where matching.DniPro == dni select matching).Single(); ;
        }

        public TbProfesore getProfesorbyName(string name)
        {
            return (from matching in database.TbProfesores where matching.NomPro == name select matching).Single();
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
