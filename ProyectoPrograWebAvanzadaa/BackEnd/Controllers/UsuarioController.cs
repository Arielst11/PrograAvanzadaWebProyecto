using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Implementations;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }



        // GET: api/<UsuarioController>
        [Authorize]
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            return _usuarioService.Get();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioModel Get(int id)
        {
           return _usuarioService.Get(id);  
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public UsuarioModel Post([FromBody] UsuarioModel usuario)
        {
            _usuarioService.Add(usuario);
            return  usuario;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public UsuarioModel Put([FromBody] UsuarioModel usuario)
        {
            _usuarioService.Update(usuario);
            return usuario;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UsuarioModel Usuario = new UsuarioModel
            {
                IdUsuario = id
            };

            _usuarioService.Remove(Usuario);
        }
    }
}
