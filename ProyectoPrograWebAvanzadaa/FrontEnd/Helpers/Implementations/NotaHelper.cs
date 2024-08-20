using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net;

namespace FrontEnd.Helpers.Implementations
{
    public class NotaHelper : INotaHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public NotaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public NotaViewModel Add(NotaViewModel nota)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/nota", Convertir(nota));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return nota;
        }

        private NotaViewModel Convertir(Nota nota)
        {
            return new NotaViewModel
            {
                IdNota = nota.IdNota,
                IdUsuario = nota.IdUsuario,
                IdTarea = nota.IdTarea,
                NotaTarea = nota.NotaTarea
            };
        }

        private Nota Convertir(NotaViewModel nota)
        {
            return new Nota
            {
                IdNota = nota.IdNota,
                IdUsuario = nota.IdUsuario,
                IdTarea = nota.IdTarea,
                NotaTarea = nota.NotaTarea
            };
        }

        public List<NotaViewModel> GetNotas()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/nota");
            List<Nota> resultado = new List<Nota>();

            if (responseMessage != null)
            {
                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("No autorizado para acceder a esta información.");

                }
                else
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<List<Nota>>(content);
                }
                
            }

            List<NotaViewModel> notas = new List<NotaViewModel>();
            foreach (var item in resultado)
            {
                notas.Add(Convertir(item));
            }

            return notas;
        }

        public NotaViewModel GetNota(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/nota/" + id.ToString());
            Nota resultado = new Nota();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Nota>(content);
            }

            return Convertir(resultado);
        }

        public NotaViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/nota/" + id.ToString());
            Nota resultado = new Nota();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public NotaViewModel Update(NotaViewModel nota)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/nota", Convertir(nota));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return nota;
        }
    }
}
