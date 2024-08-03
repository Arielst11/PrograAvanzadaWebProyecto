using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Implementations
{
    public class AsistenciasHelper : IAsistenciasHelper
    {
        IServiceRepository ServiceRepository;

        public AsistenciasHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }
        public List<AsistenciasViewModel> GetAsistencias()
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/asistencias", Convertir(asistencias));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return asistencias;
        }
    }
}
