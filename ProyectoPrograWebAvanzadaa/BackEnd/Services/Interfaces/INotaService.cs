using BackEnd.Model;
namespace BackEnd.Services.Interfaces


{
    public interface INotaService
    {
        bool Add(NotaModel nota);
        bool Remove(NotaModel nota);
        bool Update(NotaModel nota);

        NotaModel Get(int id);
        IEnumerable<NotaModel> Get();

    }
}
