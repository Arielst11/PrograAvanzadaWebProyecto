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


        private ColegiodbContext _ColegiodbContext;

        public UnidadDeTrabajo(ColegiodbContext ColegiodbContext, ITareaDAL TareaDAL)
        {
            _ColegiodbContext = ColegiodbContext;
            this.TareaDAL = TareaDAL;
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
