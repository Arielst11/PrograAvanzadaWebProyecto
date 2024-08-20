using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IClaseHelper
    {
        List<ClaseViewModel> GetClases();
        ClaseViewModel GetClase(int id);
        ClaseViewModel Add(ClaseViewModel clase);
        ClaseViewModel Remove(int id);
        ClaseViewModel Update(ClaseViewModel clase);

        public string Token { get; set; }
    }
}
