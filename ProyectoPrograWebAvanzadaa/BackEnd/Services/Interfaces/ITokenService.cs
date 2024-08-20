using BackEnd.Model;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BackEnd.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(Usuario user, List<string> roles);

    }
}
