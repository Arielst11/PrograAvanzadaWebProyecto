using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities;

public partial class Tarea
{
    [Key]
    public int IdTarea { get; set; }

    public string? NombreTarea { get; set; }

    public string? DescripcionTarea { get; set; }

    public int? ValorPorcentual { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
