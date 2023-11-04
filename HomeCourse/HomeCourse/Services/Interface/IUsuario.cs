using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IUsuario
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario getUsuariobyCod(string cod);
        Usuario getUsuariobyName(string name);
        Usuario getUsuariobyDNI(string dni);
        Usuario getUsuariobyCorreo(string correo);
        bool UsuarioExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
        void Update(Usuario cli);
    }
}
