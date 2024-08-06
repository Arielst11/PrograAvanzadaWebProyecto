using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;

namespace BackEnd.Services.Implementations
{
    public class TipoUsuarioService : ITipoUsuarioService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private ITipoUsuarioDAL _tipoUsuarioDAL;


        public TipoUsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            
        }

        private TipoUsuario Convertir (TipoUsuarioModel tipoUsuario)
        {
            TipoUsuario entity = new TipoUsuario
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                TipoUsuario1 = tipoUsuario.TipoUsuario1,
                Usuarios = tipoUsuario.Usuarios.ToList()
            };

            return entity;
        }

        private TipoUsuarioModel Convertir(TipoUsuario tipoUsuario)
        
        {

            //if (tipoUsuario == null)
            //{
            //    // Manejo de la situación donde tarea es null
            //    // Puedes lanzar una excepción, devolver null, etc.
            //    throw new ArgumentNullException(nameof(tipoUsuario), "El TipoUsuario no puede ser null");
            //}

            TipoUsuarioModel entity = new TipoUsuarioModel
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                TipoUsuario1 = tipoUsuario.TipoUsuario1,
                Usuarios = tipoUsuario.Usuarios.ToList()

            };

            return entity;
        }


        public bool Add(TipoUsuarioModel tipoUsuario)
        {
            _unidadDeTrabajo.TipoUsuarioDAL.Add(Convertir(tipoUsuario));
            return _unidadDeTrabajo.Complete();
        }

        public TipoUsuarioModel Get(int id)
        {

            return Convertir(_unidadDeTrabajo.TipoUsuarioDAL.Get(id));
        }

        public IEnumerable<TipoUsuarioModel> Get()
        {
            var lista = _unidadDeTrabajo.TipoUsuarioDAL.GetAll();
            List<TipoUsuarioModel> tipoUsuarios = new List<TipoUsuarioModel>();
            foreach (var item in lista)
            {
                tipoUsuarios.Add(Convertir(item));
            }
            return tipoUsuarios;
        }


        public bool Remove(TipoUsuarioModel tipoUsuario)
        {
            _unidadDeTrabajo.TipoUsuarioDAL.Remove(Convertir(tipoUsuario));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(TipoUsuarioModel tipoUsuario)
        {
            _unidadDeTrabajo.TipoUsuarioDAL.Update(Convertir(tipoUsuario));
            return _unidadDeTrabajo.Complete();
        }
    }
}
