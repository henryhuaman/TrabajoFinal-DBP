using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class AdministradorRepository : IAdministrador
    {
        BdWeb data = new BdWeb();
        public bool AdministradorExistsbyCorreo(string correo)
        {
            var exists = data.Administradors.Any(admin => admin.Correo == correo);
            return exists;
        }

        public Administrador getAdministradorbyCorreo(string correo)
        {
            return (from matched in data.Administradors where matched.Correo == correo select matched).Single();
        }

        public Administrador getAdministradorbyId(string id)
        {
            return (from matched in data.Administradors where matched.Id == id select matched).Single();
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingAdmin = (from admi in data.Administradors where admi.Correo == correo && admi.Contraseña == password select admi).Any();
            return matchingAdmin;
        }
    }
}
