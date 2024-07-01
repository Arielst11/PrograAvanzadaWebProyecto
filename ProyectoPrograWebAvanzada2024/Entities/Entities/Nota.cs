using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Nota
{
    public int ConsecutivoNotas { get; set; }

    public int? FkConsecutivoUsuario { get; set; }

    public int? FkConsecutivoTarea { get; set; }

    public virtual Tarea? FkConsecutivoTareaNavigation { get; set; }

    public virtual Usuario? FkConsecutivoUsuarioNavigation { get; set; }
}
