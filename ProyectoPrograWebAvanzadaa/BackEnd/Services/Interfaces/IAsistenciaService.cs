using BackEnd.Model;
namespace BackEnd.Services.Interfaces


{
    public interface IAsistenciaService
    {
        bool Add(AsistenciaModel clase);
        bool Remove(AsistenciaModel clase);
        bool Update(AsistenciaModel clase);

        AsistenciaModel Get(int id);
        IEnumerable<AsistenciaModel> Get();

    }
}
