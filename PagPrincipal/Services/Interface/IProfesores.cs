using PagPrincipal.Models;

namespace PagPrincipal.Services.Interface
{
    public interface IProfesores
    {
        IEnumerable<TbProfesore> getAllProfesores();
        TbProfesore getProfesorbyCod(string cod);
        TbProfesore getProfesorbyName(string name);
        TbProfesore getProfesorbyDNI(string dni);
        TbProfesore getProfesorbyCorreo(string correo);
        bool ProfesorExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
    }
}
