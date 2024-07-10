using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;

namespace BackEnd.Services.Implementations
{
    public class AsistenciasService : IAsistenciasService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IAsistenciasDAL _asistenciasDAL;


        public AsistenciasService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            
        }

        private Asistencias Convertir (AsistenciasModel asistencias)
        {
            Asistencias entity = new Asistencias
            {
                ConsecutivoAsistencia = asistencias.ConsecutivoAsistencia,
                Fecha = asistencias.Fecha,
                AsistenciaUsuario = asistencias.Asistencia,
                PorcentajeAsistencia = asistencias.PorcentajeAsistencia,
                FkConsecutivoUsuario = asistencias.FkConsecutivoUsuario

    };

            return entity;
        }

        private AsistenciasModel Convertir(Asistencias asistencias)
        {
            AsistenciasModel entity = new AsistenciasModel
            {
                ConsecutivoAsistencia = asistencias.ConsecutivoAsistencia,
                Fecha = asistencias.Fecha,
                Asistencia = asistencias.AsistenciaUsuario,
                PorcentajeAsistencia = asistencias.PorcentajeAsistencia,
                FkConsecutivoUsuario = asistencias.FkConsecutivoUsuario
            };

            return entity;
        }


        public bool Add(AsistenciasModel asistencias)
        {
            _unidadDeTrabajo.AsistenciasDAL.Add(Convertir(asistencias));
            return _unidadDeTrabajo.Complete();
        }

        public AsistenciasModel Get(int id)
        {

            return Convertir(_unidadDeTrabajo.AsistenciasDAL.Get(id));
        }

        public IEnumerable<AsistenciasModel> Get()
        {
            var lista = _unidadDeTrabajo.AsistenciasDAL.GetAll();
            List<AsistenciasModel> asistencias = new List<AsistenciasModel>();
            foreach (var item in lista)
            {
                asistencias.Add(Convertir(item));
            }
            return asistencias;
        }


        public bool Remove(AsistenciasModel asistencias)
        {
            _unidadDeTrabajo.AsistenciasDAL.Remove(Convertir(asistencias));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(AsistenciasModel asistencias)
        {
            _unidadDeTrabajo.AsistenciasDAL.Update(Convertir(asistencias));
            return _unidadDeTrabajo.Complete();
        }
    }
}
