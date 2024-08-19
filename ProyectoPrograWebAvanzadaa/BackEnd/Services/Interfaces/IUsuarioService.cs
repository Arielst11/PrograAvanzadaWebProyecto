using BackEnd.Model;

namespace BackEnd.Services.Interfaces

{
    public interface IUsuarioService
    {

        bool Add(UsuarioModel usuario);
        bool Remove(UsuarioModel usuario);
        bool Update(UsuarioModel usuario);

        UsuarioModel Get(int id);
        IEnumerable<UsuarioModel> Get();


    }
}
