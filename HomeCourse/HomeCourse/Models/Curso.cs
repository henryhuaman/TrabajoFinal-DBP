using System;
using System.Collections.Generic;

namespace HomeCourse.Models;

public partial class Curso
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public string ProfesorId { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();

    public virtual Profesor Profesor { get; set; } = null!;
}
