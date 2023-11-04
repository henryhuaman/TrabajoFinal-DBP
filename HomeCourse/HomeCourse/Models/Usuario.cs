using System;
using System.Collections.Generic;

namespace HomeCourse.Models;

public partial class Usuario
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public string? Dni { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
