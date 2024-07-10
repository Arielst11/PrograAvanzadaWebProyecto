using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;


namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo

    {

        public ITareaDAL TareaDAL { get; set; }
        public IClaseDAL ClaseDAL { get; set; }
        public IAsistenciasDAL AsistenciasDAL { get; set; }


        private ColegiodbContext _ColegiodbContext;

        public UnidadDeTrabajo(ColegiodbContext ColegiodbContext, 
                        ITareaDAL TareaDAL,
                        IClaseDAL claseDAL,
                        IAsistenciasDAL asistenciasDAL
            )
        {
            _ColegiodbContext = ColegiodbContext;
            this.TareaDAL = TareaDAL;
            this.ClaseDAL = claseDAL;
            this.AsistenciasDAL = asistenciasDAL;
        }

        public bool Complete()
        {
            try
            {
                _ColegiodbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._ColegiodbContext.Dispose();
        }
    }
}
