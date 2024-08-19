using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class AsistenciaDALImpl : DALGenericoImpl<Asistencia>, IAsistenciaDAL
    {
        private Colegiodb2Context _Colegiodb2Context;

        public AsistenciaDALImpl(Colegiodb2Context Colegiodb2Context) : base(Colegiodb2Context)
        {
            _Colegiodb2Context = Colegiodb2Context;
        }
    }
}
