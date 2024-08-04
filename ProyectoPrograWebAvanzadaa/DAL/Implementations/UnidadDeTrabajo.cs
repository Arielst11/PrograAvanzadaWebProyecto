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
        public IAsistenciaDAL AsistenciaDAL { get; set; }
        public INotaDAL NotaDAL { get; set; }
        public ITipoUsuarioDAL TipoUsuarioDAL { get; set; }
        public IUsuarioDAL UsuarioDAL { get; set; }


        private Colegiodb2Context _Colegiodb2Context;

        public UnidadDeTrabajo(Colegiodb2Context Colegiodb2Context, 
                        ITareaDAL TareaDAL,
                        IClaseDAL claseDAL,
                        IAsistenciaDAL asistenciaDAL,
                        INotaDAL notaDAL,
                        ITipoUsuarioDAL tipoUsuarioDAL,
                        IUsuarioDAL usuarioDAL
            )
        {
            _Colegiodb2Context = Colegiodb2Context;
            this.TareaDAL = TareaDAL;
            this.ClaseDAL = claseDAL;
            this.AsistenciaDAL = asistenciaDAL;
            this.NotaDAL = notaDAL;
            this.TipoUsuarioDAL = tipoUsuarioDAL;
            this.UsuarioDAL = usuarioDAL;
        }

        public bool Complete()
        {
            try
            {
                _Colegiodb2Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._Colegiodb2Context.Dispose();
        }
    }
}
