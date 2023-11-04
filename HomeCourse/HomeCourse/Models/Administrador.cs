using System;
using System.Collections.Generic;

namespace HomeCourse.Models;

public partial class Administrador
{
    public string Id { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }
}
