using System;
using System.Collections.Generic;

namespace PagPrincipal.Models;

public partial class TbCliente
{
    public string CodCli { get; set; } = null!;

    public string NomCli { get; set; } = null!;

    public string TlfCli { get; set; } = null!;

    public string CorCli { get; set; } = null!;

    public string ContraCli { get; set; } = null!;

    public string DniCli { get; set; } = null!;

    public virtual ICollection<TbVentum> TbVenta { get; set; } = new List<TbVentum>();
}
