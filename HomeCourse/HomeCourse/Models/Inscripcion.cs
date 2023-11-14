using System;
using System.Collections.Generic;

namespace HomeCourse.Models;

public partial class Inscripcion
{
    public string UsuarioId { get; set; } = null!;

    public string CursoId { get; set; } = null!;

    public string? InsFecha { get; set; }

    public string CodOpe { get; set; } = null!;

    public virtual Curso Curso { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
