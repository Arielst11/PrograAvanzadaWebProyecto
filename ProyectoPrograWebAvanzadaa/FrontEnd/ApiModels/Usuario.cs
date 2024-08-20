namespace FrontEnd.ApiModels
{
    public partial class Usuario
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public int? IdClase { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual Clase? IdClaseNavigation { get; set; }

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

        public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
    }
}
