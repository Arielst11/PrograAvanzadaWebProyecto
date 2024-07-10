using Entities.Entities;

namespace BackEnd.Model
{
    public class NotaModel
    {
        public int ConsecutivoNotas { get; set; }

        public int? FkConsecutivoUsuario { get; set; }

        public int? FkConsecutivoTarea { get; set; }

        public virtual Tarea? FkConsecutivoTareaNavigation { get; set; }

        public virtual Usuario? FkConsecutivoUsuarioNavigation { get; set; }

    }
}
