using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ClaseDALImpl : DALGenericoImpl<Clase>, IClaseDAL
    {
        private ColegiodbContext _ColegiodbContext;

        public ClaseDALImpl(ColegiodbContext ColegiodbContext) : base(ColegiodbContext)
        {
            _ColegiodbContext = ColegiodbContext;
        }
    }
}
