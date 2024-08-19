using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities;

public partial class Nota
{
    [Key]
    public int IdNota { get; set; }

    [ForeignKey("Usuario")]
    public string? Id { get; set; }

    [ForeignKey("Tarea")]
    public int? IdTarea { get; set; }

    public string? NotaTarea { get; set; }

    public virtual Tarea? IdTareaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
