using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

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
    }
}
