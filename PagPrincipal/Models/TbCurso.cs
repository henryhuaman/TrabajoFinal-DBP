using System;
using System.Collections.Generic;

namespace PagPrincipal.Models;

public partial class TbCurso
{
    public string CodCur { get; set; } = null!;

    public string NomCur { get; set; } = null!;

    public string DesCur { get; set; } = null!;

    public string CateCur { get; set; } = null!;

    public decimal PreCur { get; set; }

    public string CodPro { get; set; } = null!;

    public virtual TbProfesore CodProNavigation { get; set; } = null!;

    public virtual ICollection<TbVentum> TbVenta { get; set; } = new List<TbVentum>();
}
