using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Threading;


namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IUsuarioDAL _UsuarioDAL;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo; 
        }




        private Usuario Convertir(UsuarioModel usuario)
        {
            Usuario entity = new Usuario
            {
                ConsecutivoUsuario = usuario.ConsecutivoUsuario,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                FkConsecutivoTipoUsuario = usuario.FkConsecutivoTipoUsuario,
                FkConsecutivoClase = usuario.FkConsecutivoClase
            };

            return entity;
        }

        private UsuarioModel Convertir(Usuario usuario)
        {
            UsuarioModel entity = new UsuarioModel
            {
                ConsecutivoUsuario = usuario.ConsecutivoUsuario,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                FkConsecutivoTipoUsuario = usuario.FkConsecutivoTipoUsuario,
                FkConsecutivoClase = usuario.FkConsecutivoClase
            };

            return entity;
        }



        public bool Add(UsuarioModel usuario)
        {
            _unidadDeTrabajo.UsuarioDAL.Add(Convertir(usuario));
            return _unidadDeTrabajo.Complete();
        }

        public UsuarioModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.UsuarioDAL.Get(id));
        }

        public IEnumerable<UsuarioModel> Get()
        {
            var lista = _unidadDeTrabajo.UsuarioDAL.GetAll();
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();
            foreach (var item in lista)
            {
                Usuarios.Add(Convertir(item));
            }
            return Usuarios;
        }

        public bool Remove(UsuarioModel usuario)
        {
            _unidadDeTrabajo.UsuarioDAL.Remove(Convertir(usuario));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(UsuarioModel usuario)
        {
            _unidadDeTrabajo.UsuarioDAL.Update(Convertir(usuario));
            return _unidadDeTrabajo.Complete();
        }
    }
}
