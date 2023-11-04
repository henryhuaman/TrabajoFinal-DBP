using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IProfesor
    {
        IEnumerable<Profesor> GetAllProfesores();
        Profesor getProfesorbyCod(string cod);
        Profesor getProfesorbyName(string name);
        Profesor getProfesorbyDNI(string dni);
        Profesor getProfesorbyCorreo(string correo);
        bool ProfesorExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
    }
}
