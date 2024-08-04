using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface INotaHelper
    {
        List<NotaViewModel> GetNotas();
        NotaViewModel GetNota(int id);
        NotaViewModel Add(NotaViewModel nota);
        NotaViewModel Remove(int id);
        NotaViewModel Update(NotaViewModel nota);
    }
}
