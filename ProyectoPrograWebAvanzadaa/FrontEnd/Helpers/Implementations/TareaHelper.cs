using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class TareaHelper : ITareaHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public string Token { get; set; }

        public TareaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public TareaViewModel Add(TareaViewModel tarea)
        {
            _serviceRepository.Client.DefaultRequestHeaders.Authorization =
                 new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/tarea", Convertir(tarea));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return tarea;
        }

        private TareaViewModel Convertir(Tarea tarea)
        {
            return new TareaViewModel
            {
                IdTarea = tarea.IdTarea,
                NombreTarea = tarea.NombreTarea,
                DescripcionTarea = tarea.DescripcionTarea,
                ValorPorcentual = tarea.ValorPorcentual
            };
        }

        private Tarea Convertir(TareaViewModel tarea)
        {
            return new Tarea
            {
                IdTarea = tarea.IdTarea,
                NombreTarea = tarea.NombreTarea,
                DescripcionTarea = tarea.DescripcionTarea,
                ValorPorcentual = tarea.ValorPorcentual
            };
        }

        public List<TareaViewModel> GetTareas()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/tarea");
            List<Tarea> resultado = new List<Tarea>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Tarea>>(content);
            }

            List<TareaViewModel> tareas = new List<TareaViewModel>();
            foreach (var item in resultado)
            {
                tareas.Add(Convertir(item));
            }

            return tareas;
        }

        public TareaViewModel GetTarea(int id)
        {
            _serviceRepository.Client.DefaultRequestHeaders.Authorization =
                 new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/tarea/" + id.ToString());
            Tarea resultado = new Tarea();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Tarea>(content);
            }

            return Convertir(resultado);
        }

        public TareaViewModel Remove(int id)
        {
            _serviceRepository.Client.DefaultRequestHeaders.Authorization =
                 new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/tarea/" + id.ToString());
            Tarea resultado = new Tarea();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public TareaViewModel Update(TareaViewModel tarea)
        {
            _serviceRepository.Client.DefaultRequestHeaders.Authorization =
                 new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/tarea", Convertir(tarea));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return tarea;
        }
    }
}
