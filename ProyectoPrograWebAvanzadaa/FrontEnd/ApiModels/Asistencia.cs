namespace FrontEnd.ApiModels
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }

        public DateOnly? Fecha { get; set; }

        public bool? AsistenciaUsuario { get; set; }

        public int? PorcentajeAsistencia { get; set; }

        public string? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
