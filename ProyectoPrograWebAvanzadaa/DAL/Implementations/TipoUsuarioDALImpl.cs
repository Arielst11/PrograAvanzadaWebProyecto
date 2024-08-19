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

        private Colegiodb2Context _Colegiodb2Context;

        public TipoUsuarioDALImpl(Colegiodb2Context Colegiodb2Context) : base(Colegiodb2Context)
        {
            _Colegiodb2Context = Colegiodb2Context;
        }


    }
}
