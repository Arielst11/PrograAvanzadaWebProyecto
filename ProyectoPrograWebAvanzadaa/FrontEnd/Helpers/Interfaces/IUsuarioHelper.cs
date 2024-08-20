using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {
        List<UsuarioViewModel> GetUsuarios();
        UsuarioViewModel GetUsuario(string id);
        UsuarioViewModel Add(UsuarioViewModel usuario);
        UsuarioViewModel Remove(string id);
        UsuarioViewModel Update(UsuarioViewModel usuario);

        public string Token { get; set; }
    }
}
