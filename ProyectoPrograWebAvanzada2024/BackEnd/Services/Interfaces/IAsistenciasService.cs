using BackEnd.Model;
namespace BackEnd.Services.Interfaces


{
    public interface IAsistenciasService
    {
        bool Add(AsistenciasModel clase);
        bool Remove(AsistenciasModel clase);
        bool Update(AsistenciasModel clase);

        AsistenciasModel Get(int id);
        IEnumerable<AsistenciasModel> Get();

    }
}
