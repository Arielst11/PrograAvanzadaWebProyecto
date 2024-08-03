namespace FrontEnd.Models
{
    public class AsistenciasViewModel
    {
        public int ConsecutivoAsistencia { get; set; }

        public DateOnly? Fecha { get; set; }

        public bool? Asistencia { get; set; }

        public int? PorcentajeAsistencia { get; set; }

        public int? FkConsecutivoUsuario { get; set; }

        //public virtual Usuario? FkConsecutivoUsuarioNavigation { get; set; }

    }
}
