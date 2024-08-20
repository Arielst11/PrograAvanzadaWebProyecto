using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ITareaHelper
    {
        List<TareaViewModel> GetTareas();
        TareaViewModel GetTarea(int id);
        TareaViewModel Add(TareaViewModel tarea);
        TareaViewModel Remove(int id);
        TareaViewModel Update(TareaViewModel tarea);

        public string Token { get; set; }
    }
}
