using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UsuarioLoginViewModel
    {
        [Required]
        public string username { get; set; }

        [DataType (DataType.Password)]
        public string password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
