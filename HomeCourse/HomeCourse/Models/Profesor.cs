using System;
using System.Collections.Generic;

namespace HomeCourse.Models;

public partial class Profesor
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
