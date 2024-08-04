using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;

namespace BackEnd.Services.Implementations
{
    public class ClaseService : IClaseService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IClaseDAL _claseDAL;


        public ClaseService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            
        }

        private Clase Convertir (ClaseModel clase)
        {
            Clase entity = new Clase
            {
                IdClase = clase.IdClase,
                Grado = clase.Grado,
                Seccion = clase.Seccion

            };

            return entity;
        }

        private ClaseModel Convertir(Clase clase)
        {
            ClaseModel entity = new ClaseModel
            {
                IdClase = clase.IdClase,
                Grado = clase.Grado,
                Seccion = clase.Seccion
            };

            return entity;
        }


        public bool Add(ClaseModel clase)
        {
            _unidadDeTrabajo.ClaseDAL.Add(Convertir(clase));
            return _unidadDeTrabajo.Complete();
        }

        public ClaseModel Get(int id)
        {

            return Convertir(_unidadDeTrabajo.ClaseDAL.Get(id));
        }

        public IEnumerable<ClaseModel> Get()
        {
            var lista = _unidadDeTrabajo.ClaseDAL.GetAll();
            List<ClaseModel> clases = new List<ClaseModel>();
            foreach (var item in lista)
            {
                clases.Add(Convertir(item));
            }
            return clases;
        }


        public bool Remove(ClaseModel clase)
        {
            _unidadDeTrabajo.ClaseDAL.Remove(Convertir(clase));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(ClaseModel clase)
        {
            _unidadDeTrabajo.ClaseDAL.Update(Convertir(clase));
            return _unidadDeTrabajo.Complete();
        }
    }
}
