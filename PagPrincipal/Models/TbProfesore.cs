using System;
using System.Collections.Generic;

namespace PagPrincipal.Models;

public partial class TbProfesore
{
    public string CodPro { get; set; } = null!;

    public string NomPro { get; set; } = null!;

    public string DesPro { get; set; } = null!;

    public string TlfPro { get; set; } = null!;

    public string CorPro { get; set; } = null!;

    public string ContraPro { get; set; } = null!;

    public string DniPro { get; set; } = null!;

    public virtual ICollection<TbCurso> TbCursos { get; set; } = new List<TbCurso>();
}
