using BackEnd.Model;
namespace BackEnd.Services.Interfaces


{
    public interface IClaseService
    {
        bool Add(ClaseModel clase);
        bool Remove(ClaseModel clase);
        bool Update(ClaseModel clase);

        ClaseModel Get(int id);
        IEnumerable<ClaseModel> Get();

    }
}
