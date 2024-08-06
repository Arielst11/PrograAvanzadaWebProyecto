using FrontEnd.ApiModels;

namespace FrontEnd.Models
{
    public class NotaViewModel
    {
        public int IdNota { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdTarea { get; set; }

        public string? NotaTarea { get; set; }

        public virtual Tarea? IdTareaNavigation { get; set; }

       public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
