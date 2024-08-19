using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Implementations
{
    public class AsistenciaService : IAsistenciaService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IAsistenciaDAL _asistenciaDAL;


        public AsistenciaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;

        }

        private Asistencia Convertir(AsistenciaModel asistencia)
        {
            Asistencia entity = new Asistencia
            {
                IdAsistencia = asistencia.IdAsistencia,
                Fecha = asistencia.Fecha,
                AsistenciaUsuario = asistencia.AsistenciaUsuario,
                PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                Id = asistencia.Id
            };

            return entity;
        }

        private AsistenciaModel Convertir(Asistencia asistencia)
        {
            AsistenciaModel entity = new AsistenciaModel
            {
                IdAsistencia = asistencia.IdAsistencia,
                Fecha = asistencia.Fecha,
                AsistenciaUsuario = asistencia.AsistenciaUsuario,
                PorcentajeAsistencia = asistencia.PorcentajeAsistencia,
                Id = asistencia.Id
            };

            return entity;
        }


        public bool Add(AsistenciaModel asistencia)
        {
            _unidadDeTrabajo.AsistenciaDAL.Add(Convertir(asistencia));
            return _unidadDeTrabajo.Complete();
        }

        public AsistenciaModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.AsistenciaDAL.Get(id));
        }

        public IEnumerable<AsistenciaModel> Get()
        {
            var lista = _unidadDeTrabajo.AsistenciaDAL.GetAll();
            List<AsistenciaModel> asistenciaList = new List<AsistenciaModel>();
            foreach (var item in lista)
            {
                asistenciaList.Add(Convertir(item));
            }
            return asistenciaList;
        }


        public bool Remove(AsistenciaModel asistencia)
        {
            _unidadDeTrabajo.AsistenciaDAL.Remove(Convertir(asistencia));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(AsistenciaModel asistencia)
        {
            _unidadDeTrabajo.AsistenciaDAL.Update(Convertir(asistencia));
            return _unidadDeTrabajo.Complete();
        }
    }
}
