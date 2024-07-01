using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int ConsecutivoUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public int? FkConsecutivoTipoUsuario { get; set; }

    public int? FkConsecutivoClase { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

    public virtual Clase? FkConsecutivoClaseNavigation { get; set; }

    public virtual TipoUsuario? FkConsecutivoTipoUsuarioNavigation { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
