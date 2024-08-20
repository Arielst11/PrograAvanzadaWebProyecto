using FrontEnd.ApiModels;

namespace FrontEnd.Models
{
    public class NotaViewModel
    {
        public int IdNota { get; set; }

        public string? Id { get; set; }

        public int? IdTarea { get; set; }

        public string? NotaTarea { get; set; }

        public virtual Tarea? Tarea { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
