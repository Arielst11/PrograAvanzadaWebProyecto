using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ITipoUsuarioHelper
    {
        List<TipoUsuarioViewModel> GetTipoUsuarios();
        TipoUsuarioViewModel GetTipoUsuario(int id);
        TipoUsuarioViewModel Add(TipoUsuarioViewModel tipoUsuario);
        TipoUsuarioViewModel Remove(int id);
        TipoUsuarioViewModel Update(TipoUsuarioViewModel tipoUsuario);
    }
}
