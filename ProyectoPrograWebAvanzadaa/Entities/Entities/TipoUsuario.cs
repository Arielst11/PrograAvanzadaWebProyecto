using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class TipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string? TipoUsuario1 { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
