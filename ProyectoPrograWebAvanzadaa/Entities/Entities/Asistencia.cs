using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities;

public partial class Asistencia
{
    [Key]
    public int IdAsistencia { get; set; }

    public DateOnly? Fecha { get; set; }

    public bool? AsistenciaUsuario { get; set; }

    public int? PorcentajeAsistencia { get; set; }

    [ForeignKey("Usuario")]
    public string? Id { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
