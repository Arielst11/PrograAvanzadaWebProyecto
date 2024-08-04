using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public UsuarioHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
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
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                IdTipoUsuario = usuario.IdTipoUsuario,
                IdClase = usuario.IdClase
            };
        }

        private Usuario Convertir(UsuarioViewModel usuario)
        {
            return new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                IdTipoUsuario = usuario.IdTipoUsuario,
                IdClase = usuario.IdClase
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

        public UsuarioViewModel GetUsuario(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/usuario/" + id.ToString());
            Usuario resultado = new Usuario();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Usuario>(content);
            }

            return Convertir(resultado);
        }

        public UsuarioViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/usuario/" + id.ToString());
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
