using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.Implementations
{
    public class TipoUsuarioDALImpl : DALGenericoImpl<TipoUsuario> , ITipoUsuarioDAL
    {

        private ColegiodbContext _ColegiodbContext;

        public TipoUsuarioDALImpl(ColegiodbContext ColegiodbContext) : base(ColegiodbContext)
        {
            _ColegiodbContext = ColegiodbContext;
        }


    }
}
