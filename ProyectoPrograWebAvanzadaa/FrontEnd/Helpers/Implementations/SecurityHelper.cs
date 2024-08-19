using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository ServiceRepository;

        public SecurityHelper(IServiceRepository serviceRepository) 
        {
            ServiceRepository = serviceRepository;
        }


        public LoginAPI GetUser(UsuarioLoginViewModel usuario)
        {
            return new LoginAPI();
        }

        public LoginAPI Login(UsuarioLoginViewModel usuario)
        {
            try
            {
                TokenAPI token = new TokenAPI();

                HttpResponseMessage responseMessage = ServiceRepository
                                .PostResponse("/api/Auth/login", new { usuario.username, usuario.password });
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                LoginAPI LoginAPI = JsonConvert.DeserializeObject<LoginAPI>(content);

                token = LoginAPI.Token;

                return LoginAPI;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
