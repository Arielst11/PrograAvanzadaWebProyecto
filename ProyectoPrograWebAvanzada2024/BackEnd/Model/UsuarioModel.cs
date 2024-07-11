using Entities.Entities;

namespace BackEnd.Model
{
    public class UsuarioModel
    {
        public int ConsecutivoUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public int? FkConsecutivoTipoUsuario { get; set; }

        public int? FkConsecutivoClase { get; set; }

        public virtual ICollection<Asistencias> Asistencia { get; set; } = new List<Asistencias>();

        public virtual Clase? FkConsecutivoClaseNavigation { get; set; }

        public virtual TipoUsuario? FkConsecutivoTipoUsuarioNavigation { get; set; }

        public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    }
}
