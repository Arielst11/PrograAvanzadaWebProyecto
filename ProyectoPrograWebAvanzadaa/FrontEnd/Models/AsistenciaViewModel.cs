using FrontEnd.ApiModels;
using System.ComponentModel;

namespace FrontEnd.Models
{
    public class AsistenciaViewModel
    {
        [DisplayName("ID")]

        public int IdAsistencia { get; set; }

        public DateOnly? Fecha { get; set; }

        [DisplayName ("Asistió?")]
        public bool? AsistenciaUsuario { get; set; }

        [DisplayName("Porcentaje de Asistencia")]
        public int? PorcentajeAsistencia { get; set; }

        [DisplayName("Id Usuario")]
        public string? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        
    }
}
