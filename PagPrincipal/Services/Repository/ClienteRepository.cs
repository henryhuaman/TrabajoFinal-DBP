using PagPrincipal.Models;
using PagPrincipal.Services.Interface;

namespace PagPrincipal.Services.Repository
{
    public class ClienteRepository : ICliente
    {
        private BdWeb database = new BdWeb();
        public bool ClienteExistsbyCorreo(string correo)
        {
            var matchingClient = database.TbClientes.Any(clients => clients.CorCli == correo);
            return matchingClient;
        }

        public IEnumerable<TbCliente> getAllClientes()
        {
            return database.TbClientes;
        }

        public TbCliente getClientebyCod(string cod)
        {
            return database.TbClientes.Single(client => client.CodCli == cod);
        }

        public TbCliente getClientebyCorreo(string correo)
        {
            return (from matching in database.TbClientes where matching.CorCli == correo select matching).Single();
        }

        public TbCliente getClientebyDNI(string dni)
        {
            return database.TbClientes.Single(client => client.DniCli == dni);
        }

        public TbCliente getClientebyName(string name)
        {
            return database.TbClientes.Single(client => client.NomCli == name);
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingClient = (from CLIENT in database.TbClientes where CLIENT.CorCli == correo && CLIENT.ContraCli == password select CLIENT).Any();
            return matchingClient;
        }
    }
}
