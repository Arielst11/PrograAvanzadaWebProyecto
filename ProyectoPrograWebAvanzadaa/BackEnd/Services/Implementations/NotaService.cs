using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;

namespace BackEnd.Services.Implementations
{
    public class NotaService : INotaService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private INotaDAL _notaDAL;


        public NotaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            
        }

        private Nota Convertir (NotaModel nota)
        {
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota), "El objeto Nota es null.");
            }

            Nota entity = new Nota
            {
                IdNota = nota.IdNota,
                Id = nota.Id,
                IdTarea = nota.IdTarea,
                NotaTarea = nota.NotaTarea

            };

            return entity;
        }

        private NotaModel Convertir(Nota nota)
        {
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota), "El objeto Nota es null.");
            }

            NotaModel entity = new NotaModel
            {
                IdNota = nota.IdNota,
                Id = nota.Id,
                IdTarea = nota.IdTarea,
                NotaTarea = nota.NotaTarea
            };

            return entity;
        }


        public bool Add(NotaModel nota)
        {
            _unidadDeTrabajo.NotaDAL.Add(Convertir(nota));
            return _unidadDeTrabajo.Complete();
        }

        public NotaModel Get(int id)
        {

            return Convertir(_unidadDeTrabajo.NotaDAL.Get(id));
        }

        public IEnumerable<NotaModel> Get()
        {
            var lista = _unidadDeTrabajo.NotaDAL.GetAll();
            List<NotaModel> notas = new List<NotaModel>();
            foreach (var item in lista)
            {
                notas.Add(Convertir(item));
            }
            return notas;
        }


        public bool Remove(NotaModel nota)
        {
            _unidadDeTrabajo.NotaDAL.Remove(Convertir(nota));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(NotaModel nota)
        {
            _unidadDeTrabajo.NotaDAL.Update(Convertir(nota));
            return _unidadDeTrabajo.Complete();
        }
    }
}
