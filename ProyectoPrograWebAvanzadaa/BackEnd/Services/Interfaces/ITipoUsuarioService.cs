using BackEnd.Model;
using Entities.Entities;
namespace BackEnd.Services.Interfaces


{
    public interface ITipoUsuarioService
    {
        bool Add(TipoUsuarioModel tipoUsuario);
        bool Remove(TipoUsuarioModel tipoUsuario);
        bool Update(TipoUsuarioModel tipoUsuario);

        TipoUsuarioModel Get(int id);
        IEnumerable<TipoUsuarioModel> Get();


    }
}
