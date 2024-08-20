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
            try
            {
                if (asistencia == null)
                {
                    // Si asistencia es null, retorna un objeto vacío o maneja el caso según sea necesario
                    return null;
                }
                return new AsistenciaViewModel
                {  
                    IdAsistencia = asistencia.IdAsistencia,
                    Fecha = asistencia.Fecha,
                    AsistenciaUsuario = asistencia.AsistenciaUsuario,
                    PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                    Id = asistencia.Id
                };
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, el objeto puede no ser creado correctamente
                // Opcionalmente podrías registrar el error o manejarlo de otra forma
                // Por ejemplo: _logger.LogError(ex, "Error al convertir asistencia a AsistenciaViewModel.");

                // Retorna un objeto vacío o nulo si ocurre un error para evitar que se caiga la aplicación
                return null; // o return null;
            }
        }

        private Asistencia Convertir(AsistenciaViewModel asistencia)
        {
            return new Asistencia
            {
                IdAsistencia = asistencia.IdAsistencia,
                Fecha = asistencia.Fecha,
                AsistenciaUsuario = asistencia.AsistenciaUsuario,
                PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                Id = asistencia.Id
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
