using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.Implementations
{
    public class TareaDALImpl : DALGenericoImpl<Tarea> , ITareaDAL
    {

        private Colegiodb2Context _Colegiodb2Context;

        public TareaDALImpl(Colegiodb2Context Colegiodb2Context) : base(Colegiodb2Context)
        {
            _Colegiodb2Context = Colegiodb2Context;
        }


    }
}
