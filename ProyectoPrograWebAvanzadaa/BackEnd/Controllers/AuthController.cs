using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Usuario> userManager;
        private ITokenService TokenService;

        public AuthController(UserManager<Usuario> userManager,
                                ITokenService tokenService)
        {
                this.userManager = userManager;
            this.TokenService = tokenService;   
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {


            Usuario user = await userManager.FindByNameAsync(model.Username);
            LoginModel Usuario = new LoginModel();
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
               
                var userRoles = await userManager.GetRolesAsync(user);

                var jwtToken = TokenService.CreateToken(user, userRoles.ToList());

                Usuario.Token = jwtToken;   
                Usuario.Roles = userRoles.ToList();
                Usuario.Username = user.UserName;


                return Ok(Usuario);
            }

            return Unauthorized();

               
        
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.UserName);

            if (userExists != null) {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }


            Usuario user = new Usuario
            {
                    Email = model.Email, 
                    UserName = model.UserName,
                    Nombre = model.Nombre,
                    PrimerApellido = model.PrimerApellido,
                    SegundoApellido = model.SegundoApellido


            };

            //  Task resultRole;
            //resultRole = userManager.AddToRoleAsync(user, "Estudiante"); //role asignation.


            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "INternal server Error" });

                }


                var roleAssign = await userManager.AddToRoleAsync(user, "Profesor");
                if (!roleAssign.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role could not be assigned" });

                }



                return Ok(new Response { Status = "Success", Message = "Usuario Creado" });
            }
            catch (DbUpdateException ex)
            {
                // Manejo del error con detalles adicionales
                Console.WriteLine($"Error al actualizar la base de datos: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle del error interno: {ex.InnerException.Message}");
                }
                return Ok(new Response { Status = "Fail", Message = "Usuario no Creado" });
            }

        }

        }
    }
