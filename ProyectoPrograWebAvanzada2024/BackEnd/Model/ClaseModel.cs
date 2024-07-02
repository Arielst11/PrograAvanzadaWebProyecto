using Entities.Entities;

namespace BackEnd.Model
{
    public class ClaseModel
    {
        public int ConsecutivoClase { get; set; }

        public string? Grado { get; set; }

        public string? Seccion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
