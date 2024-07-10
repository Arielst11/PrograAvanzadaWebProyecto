using Entities.Entities;

namespace BackEnd.Model
{
    public class TipoUsuarioModel
    {

        public int ConsecutivoTipoUsuario { get; set; }

        public string? TipoUsuario1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
