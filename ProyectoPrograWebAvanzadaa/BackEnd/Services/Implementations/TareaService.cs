using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;

namespace BackEnd.Services.Implementations
{
    public class TareaService : ITareaService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private ITareaDAL _tareaDAL;


        public TareaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            
        }

        private Tarea Convertir (TareaModel tarea)
        {
            Tarea entity = new Tarea
            {
                IdTarea = tarea.IdTarea,
                NombreTarea = tarea.NombreTarea,
                DescripcionTarea = tarea.DescripcionTarea,
                ValorPorcentual = tarea.ValorPorcentual

            };

            return entity;
        }

        private TareaModel Convertir(Tarea tarea)
        {
            TareaModel entity = new TareaModel
            {
                IdTarea = tarea.IdTarea,
                NombreTarea = tarea.NombreTarea,
                DescripcionTarea = tarea.DescripcionTarea,
                ValorPorcentual = tarea.ValorPorcentual
            };

            return entity;
        }


        public bool Add(TareaModel tarea)
        {
            _unidadDeTrabajo.TareaDAL.Add(Convertir(tarea));
            return _unidadDeTrabajo.Complete();
        }

        public TareaModel Get(int id)
        {

            return Convertir(_unidadDeTrabajo.TareaDAL.Get(id));
        }

        public IEnumerable<TareaModel> Get()
        {
            var lista = _unidadDeTrabajo.TareaDAL.GetAll();
            List<TareaModel> tareas = new List<TareaModel>();
            foreach (var item in lista)
            {
                tareas.Add(Convertir(item));
            }
            return tareas;
        }


        public bool Remove(TareaModel tarea)
        {
            _unidadDeTrabajo.TareaDAL.Remove(Convertir(tarea));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(TareaModel tarea)
        {
            _unidadDeTrabajo.TareaDAL.Update(Convertir(tarea));
            return _unidadDeTrabajo.Complete();
        }
    }
}
