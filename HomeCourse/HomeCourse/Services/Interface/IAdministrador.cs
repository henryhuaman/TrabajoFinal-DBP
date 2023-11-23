
using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IAdministrador
    {
        bool AdministradorExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
        Administrador getAdministradorbyCorreo(string correo);
        Administrador getAdministradorbyId(string id);
    }
}
