using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FrontEnd.ApiModels;
using Microsoft.AspNetCore.Http;
using FrontEnd.Helpers.Implementations;

namespace FrontEnd.Controllers
{
    public class AccountController : Controller
    {


        ISecurityHelper SecurityHelper;

        public AccountController(ISecurityHelper securityHelper)
        {
            SecurityHelper = securityHelper;
        }

        public IActionResult Login(string ReturneUrl = "/")
        {

            UserViewModel user = new UserViewModel();
            user.ReturnUrl = ReturneUrl;
            return View(user);
        }


        





        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var loginModel = SecurityHelper.Login(user);

                    TokenAPI tokenModel = loginModel.Token;
                  

                    var EsValido = false;
                    if (tokenModel != null)
                    {
                        EsValido = true;
                        HttpContext.Session.SetString("token", tokenModel.Token);  // . -----------------------------------> variable de sesion
                        //HttpContext.Session.SetString("Username", loginModel.Username);

                    }


                    // var user = users.Where(x => x.Username == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();


                    if (!EsValido)
                    {
                        ViewBag.Message = "Invalid Credentials";  /// el api no retorno el usuario no lo encontro
                        return View(user); ///-----> esta vista no se si existe
                    }

                    var claims = new List<Claim>() {
                                     new Claim(ClaimTypes.NameIdentifier, loginModel.Username as string),
                                         new Claim(ClaimTypes.Name, loginModel.Username as string)
                    };

                    foreach (var item in loginModel.Roles)
                    {
                        claims.Add(
                              new Claim(ClaimTypes.Role, item as string)

                            );
                    }




                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = user.RememberLogin
                    });
                    //return View("AccessDenied");
                    return LocalRedirect(user.ReturnUrl);
                }

                return View(user);



            }
            catch (Exception)
            {

                throw;
            }

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
