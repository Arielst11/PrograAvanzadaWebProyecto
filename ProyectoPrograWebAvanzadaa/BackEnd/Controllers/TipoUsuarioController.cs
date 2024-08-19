using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }



        // GET: api/<TipoUsuarioController>
        [HttpGet]
        public IEnumerable<TipoUsuarioModel> Get()
        {
            return _tipoUsuarioService.Get();
        }


        // GET api/<TipoUsuarioController>/5
        [HttpGet("{id}")]
        public TipoUsuarioModel Get(int id)
        {
            return _tipoUsuarioService.Get(id);

        }


        // POST api/<TipoUsuarioController>
        [HttpPost]
        public TipoUsuarioModel Post([FromBody] TipoUsuarioModel tipoUsuario)
        {
            _tipoUsuarioService.Add(tipoUsuario);
            return tipoUsuario;

        }

        // PUT api/<TipoUsuarioController>/5
        [HttpPut]
        public TipoUsuarioModel Put([FromBody] TipoUsuarioModel tipoUsuario)
        {
            _tipoUsuarioService.Update(tipoUsuario);
            return tipoUsuario;

        }

        // DELETE api/<TipoUsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            TipoUsuarioModel tipoUsuario = new TipoUsuarioModel
            {
                IdTipoUsuario = id
            };

            _tipoUsuarioService.Remove(tipoUsuario);
        }
    }
}
