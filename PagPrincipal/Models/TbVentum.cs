using System;
using System.Collections.Generic;

namespace PagPrincipal.Models;

public partial class TbVentum
{
    public int CodCompra { get; set; }

    public string CodCli { get; set; } = null!;

    public string CodCur { get; set; } = null!;

    public DateTime FechaCompra { get; set; }

    public decimal? Total { get; set; }

    public virtual TbCliente CodCliNavigation { get; set; } = null!;

    public virtual TbCurso CodCurNavigation { get; set; } = null!;
}
