using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ClaseHelper : IClaseHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public ClaseHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public ClaseViewModel Add(ClaseViewModel clase)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/clase", Convertir(clase));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return clase;
        }

        private ClaseViewModel Convertir(Clase clase)
        {
            return new ClaseViewModel
            {
                IdClase = clase.IdClase,
                Grado = clase.Grado,
                Seccion = clase.Seccion
            };
        }

        private Clase Convertir(ClaseViewModel clase)
        {
            return new Clase
            {
                IdClase = clase.IdClase,
                Grado = clase.Grado,
                Seccion = clase.Seccion
            };
        }

        public List<ClaseViewModel> GetClases()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/clase");
            List<Clase> resultado = new List<Clase>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Clase>>(content);
            }

            List<ClaseViewModel> clases = new List<ClaseViewModel>();
            foreach (var item in resultado)
            {
                clases.Add(Convertir(item));
            }

            return clases;
        }

        public ClaseViewModel GetClase(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/clase/" + id.ToString());
            Clase resultado = new Clase();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Clase>(content);
            }

            return Convertir(resultado);
        }

        public ClaseViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/clase/" + id.ToString());
            Clase resultado = new Clase();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public ClaseViewModel Update(ClaseViewModel clase)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/clase", Convertir(clase));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return clase;
        }
    }
}
