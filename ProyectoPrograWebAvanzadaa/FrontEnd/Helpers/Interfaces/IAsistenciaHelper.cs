using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IAsistenciaHelper
    {
        List<AsistenciaViewModel> GetAsistencias();
        AsistenciaViewModel GetAsistencia(int id);
        AsistenciaViewModel Add(AsistenciaViewModel asistencia);
        AsistenciaViewModel Remove(int id);
        AsistenciaViewModel Update(AsistenciaViewModel asistencia);

        public string Token { get; set; }
    }
}
