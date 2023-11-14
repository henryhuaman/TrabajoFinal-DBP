using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class UsuarioRepository : IUsuario
    {   
        private BdWeb bd = new BdWeb();
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return bd.Usuarios;
        }

        public Usuario getUsuariobyCod(string cod)
        {
            return bd.Usuarios.Single(client => client.Id == cod);
        }

        public Usuario getUsuariobyCorreo(string correo)
        {
            return (from matching in bd.Usuarios where matching.Correo == correo select matching).Single();
        }

        public Usuario getUsuariobyDNI(string dni)
        {
            return bd.Usuarios.Single(client => client.Dni == dni);
        }

        public Usuario getUsuariobyName(string name)
        {
            return bd.Usuarios.Single(client => client.Nombre == name);
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingClient = (from CLIENT in bd.Usuarios where CLIENT.Correo == correo && CLIENT.Contraseña == password select CLIENT).Any();
            return matchingClient;
        }

        public void Update(Usuario cli)
        {
            var objAModificado = (from tcliente in bd.Usuarios
                                  where tcliente.Id == cli.Id
                                  select tcliente).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.Id = cli.Id;
                objAModificado.Nombre = cli.Nombre;
                objAModificado.Correo = cli.Correo;
                objAModificado.Contraseña = cli.Contraseña;
                objAModificado.Dni = cli.Dni;

                bd.SaveChanges();
            }
        }

        public bool UsuarioExistsbyCorreo(string correo)
        {
            var matchingClient = bd.Usuarios.Any(clients => clients.Correo == correo);
            return matchingClient;
        }
    }
}
