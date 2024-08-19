using FrontEnd.ApiModels;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginAPI GetUser(UsuarioLoginViewModel usuario);

        LoginAPI Login(UsuarioLoginViewModel usuario);
    }
}
