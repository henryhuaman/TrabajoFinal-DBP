using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class ProfesorRepository : IProfesor
    {
        BDWeb bd = new BDWeb();

        public IEnumerable<Profesor> GetAllProfesores()
        {
            return bd.Profesors;
        }

        public Profesor getProfesorbyCod(string cod)
        {
            return (from matching in bd.Profesors where matching.Id == cod select matching).Single();
        }

        public Profesor getProfesorbyCorreo(string correo)
        {
            return (from matched in bd.Profesors where matched.Correo == correo select matched).Single();
        }

        public Profesor getProfesorbyDNI(string dni)
        {
            return (from matching in bd.Profesors where matching.Dni == dni select matching).Single();
        }

        public Profesor getProfesorbyName(string name)
        {
            return (from matching in bd.Profesors where matching.Nombre == name select matching).Single();
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingProfesor = (from profesor in bd.Profesors where profesor.Correo == correo && profesor.Contraseña == password select profesor).Any();

            return matchingProfesor;
        }

        public bool ProfesorExistsbyCorreo(string correo)
        {
            var exists = bd.Profesors.Any(profesor => profesor.Correo == correo);
            return exists;
        }
    }
}
