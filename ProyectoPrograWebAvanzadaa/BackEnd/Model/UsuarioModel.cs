using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class UsuarioModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nombre is required")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Primer Apellido is required")]
        public string? PrimerApellido { get; set; }

        [Required(ErrorMessage = "Segundo Apellido is required")]
        public string? SegundoApellido { get; set; }
        
        public string Role { get; set; }

        public int? IdClase { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual Clase? IdClaseNavigation { get; set; }

        public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    }
}
