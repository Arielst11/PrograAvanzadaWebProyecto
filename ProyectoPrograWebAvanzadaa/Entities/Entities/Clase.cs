using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Clase
{
    public int IdClase { get; set; }

    public string? Grado { get; set; }

    public string? Seccion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
