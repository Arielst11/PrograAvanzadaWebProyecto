using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public DateOnly? Fecha { get; set; }

    public bool? AsistenciaUsuario { get; set; }

    public int? PorcentajeAsistencia { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
