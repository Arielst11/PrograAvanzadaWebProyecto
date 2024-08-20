using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Entities.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> userManager;
        private IUsuarioService _usuarioService;

        public UsuarioController(UserManager<Usuario> userManager, IUsuarioService usuarioService)
        {
            this.userManager = userManager;
            _usuarioService = usuarioService;
        }



        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            return _usuarioService.Get();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioModel Get(string id)
        {
           return _usuarioService.Get(id);  
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UsuarioModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }


            Usuario user = new Usuario
            {

                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Nombre = model.Nombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido

            };

            //  Task resultRole;
            //resultRole = userManager.AddToRoleAsync(user, "Estudiante"); //role asignation.



            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "INternal server Error" });
            }


            var roleAssign = await userManager.AddToRoleAsync(user, model.Role);
            if (!roleAssign.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role could not be assigned" });

            }



            return Ok(new Response { Status = "Success", Message = "Usuario Creado" });

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
        public void Delete(string id)
        {
            UsuarioModel Usuario = new UsuarioModel
            {
                Id = id
            };

            _usuarioService.Remove(Usuario);
        }
    }
}
