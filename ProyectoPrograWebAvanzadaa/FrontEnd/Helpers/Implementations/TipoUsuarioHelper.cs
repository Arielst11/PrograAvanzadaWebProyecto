using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class TipoUsuarioHelper : ITipoUsuarioHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public TipoUsuarioHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public TipoUsuarioViewModel Add(TipoUsuarioViewModel tipoUsuario)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/tipoUsuario", Convertir(tipoUsuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return tipoUsuario;
        }

        private TipoUsuarioViewModel Convertir(TipoUsuario tipoUsuario)
        {
            return new TipoUsuarioViewModel
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                TipoUsuario1 = tipoUsuario.TipoUsuario1
            };
        }

        private TipoUsuario Convertir(TipoUsuarioViewModel tipoUsuario)
        {
            return new TipoUsuario
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                TipoUsuario1 = tipoUsuario.TipoUsuario1
            };
        }

        public List<TipoUsuarioViewModel> GetTipoUsuarios()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/tipousuario");
            List<TipoUsuario> resultado = new List<TipoUsuario>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<TipoUsuario>>(content);
            }

            List<TipoUsuarioViewModel> tipoUsuarios = new List<TipoUsuarioViewModel>();
            foreach (var item in resultado)
            {
                tipoUsuarios.Add(Convertir(item));
            }

            return tipoUsuarios;
        }

        public TipoUsuarioViewModel GetTipoUsuario(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/tipousuario/" + id.ToString());
            TipoUsuario resultado = new TipoUsuario();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<TipoUsuario>(content);
            }

            return Convertir(resultado);
        }

        public TipoUsuarioViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/tipousuario/" + id.ToString());
            TipoUsuario resultado = new TipoUsuario();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public TipoUsuarioViewModel Update(TipoUsuarioViewModel tipoUsuario)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/tipoUsuario", Convertir(tipoUsuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return tipoUsuario;
        }
    }
}
