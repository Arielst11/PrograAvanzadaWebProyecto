using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        ITareaDAL TareaDAL { get; }
        IClaseDAL ClaseDAL { get; }
        IAsistenciaDAL AsistenciaDAL { get; }
        INotaDAL NotaDAL { get; }
        ITipoUsuarioDAL TipoUsuarioDAL { get; }

        IUsuarioDAL UsuarioDAL { get; }


        bool Complete();
    }
}
