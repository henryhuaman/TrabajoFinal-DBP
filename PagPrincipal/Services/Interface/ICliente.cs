using PagPrincipal.Models;

namespace PagPrincipal.Services.Interface
{
    public interface ICliente
    {
        IEnumerable<TbCliente> getAllClientes();
        TbCliente getClientebyCod(string cod);
        TbCliente getClientebyName(string name);
        TbCliente getClientebyDNI(string dni);
        TbCliente getClientebyCorreo(string correo);
        bool ClienteExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
    }
}
