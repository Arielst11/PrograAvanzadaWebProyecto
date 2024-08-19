﻿using Entities.Entities;

namespace BackEnd.Model
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public int? IdTipoUsuario { get; set; }

        public int? IdClase { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual Clase? IdClaseNavigation { get; set; }

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

        public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    }
}
