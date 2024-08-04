using Entities.Entities;

namespace BackEnd.Model
{
    public class TareaModel
    {

        public int IdTarea { get; set; }

        public string? NombreTarea { get; set; }

        public string? DescripcionTarea { get; set; }

        public int? ValorPorcentual { get; set; }

        public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();


    }
}
