using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class AsistenciaHelper : IAsistenciaHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public string Token { get; set; }

        public AsistenciaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public AsistenciaViewModel Add(AsistenciaViewModel asistencia)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/asistencia", Convertir(asistencia));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return asistencia;
        }

        private AsistenciaViewModel Convertir(Asistencia asistencia)
        {
            return new AsistenciaViewModel
            {
                IdAsistencia = asistencia.IdAsistencia,
                Fecha = asistencia.Fecha,
                AsistenciaUsuario = asistencia.AsistenciaUsuario,
                PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                IdUsuario = asistencia.IdUsuario
            };
        }

        private Asistencia Convertir(AsistenciaViewModel asistencia)
        {
            return new Asistencia
            {
                IdAsistencia = asistencia.IdAsistencia,
                Fecha = asistencia.Fecha,
                AsistenciaUsuario = asistencia.AsistenciaUsuario,
                PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                IdUsuario = asistencia.IdUsuario
            };
        }

        public List<AsistenciaViewModel> GetAsistencias()
        {


            // -------------------------------------> se manda el token en el header del request
            _serviceRepository.Client.DefaultRequestHeaders.Authorization =
                 new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/asistencia");
            List<Asistencia> resultado = new List<Asistencia>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Asistencia>>(content);
            }

            List<AsistenciaViewModel> asistencias = new List<AsistenciaViewModel>();
            foreach (var item in resultado)
            {
                asistencias.Add(Convertir(item));
            }

            return asistencias;
        }

        public AsistenciaViewModel GetAsistencia(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/asistencia/" + id.ToString());
            Asistencia resultado = new Asistencia();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Asistencia>(content);
            }

            return Convertir(resultado);
        }

        public AsistenciaViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/asistencia/" + id.ToString());
            Asistencia resultado = new Asistencia();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return Convertir(resultado);
        }

        public AsistenciaViewModel Update(AsistenciaViewModel asistencia)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/asistencia", Convertir(asistencia));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return asistencia;
        }
    }
}
