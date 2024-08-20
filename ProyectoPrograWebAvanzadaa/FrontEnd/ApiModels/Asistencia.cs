namespace FrontEnd.ApiModels
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }

        public DateOnly? Fecha { get; set; }

        public bool? AsistenciaUsuario { get; set; }

        public int? PorcentajeAsistencia { get; set; }

        public string? Id { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
