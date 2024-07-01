using BackEnd.Model;
namespace BackEnd.Services.Interfaces


{
    public interface ITareaService
    {



        bool Add(TareaModel tarea);
        bool Remove(TareaModel tarea);
        bool Update(TareaModel tarea);

        TareaModel Get(int id);
        IEnumerable<TareaModel> Get();


    }
}
