using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper
    {
         IServiceRepository _serviceRepository;

        public string Token { get; set; }

        public UsuarioHelper(IServiceRepository serviceRepository)
        {
           this._serviceRepository = serviceRepository;
        }

        public UsuarioViewModel Add(UsuarioViewModel usuario)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/usuario", Convertir(usuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return usuario;
        }

        private UsuarioViewModel Convertir(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                IdClase = usuario.IdClase,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Password = usuario.Password
            };
        }

        private Usuario Convertir(UsuarioViewModel usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                IdClase = usuario.IdClase,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Password = usuario.Password
            };
        }

        public List<UsuarioViewModel> GetUsuarios()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/usuario");
            List<Usuario> resultado = new List<Usuario>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Usuario>>(content);
            }

            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();
            foreach (var item in resultado)
            {
                usuarios.Add(Convertir(item));
            }

            return usuarios;
        }

        public UsuarioViewModel GetUsuario(string id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/usuario/" + id);
            Usuario resultado = new Usuario();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Usuario>(content);
            }

            return Convertir(resultado);
        }

        public UsuarioViewModel Remove(string id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/usuario/" + id);
            Usuario resultado = new Usuario();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public UsuarioViewModel Update(UsuarioViewModel usuario)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/usuario", Convertir(usuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
            return usuario;
        }
    }
}
