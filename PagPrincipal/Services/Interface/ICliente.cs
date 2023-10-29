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
    }
}
