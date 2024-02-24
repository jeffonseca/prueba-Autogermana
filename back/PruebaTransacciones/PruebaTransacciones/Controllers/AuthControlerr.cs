using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTransacciones.Data;
using PruebaTransacciones.Interfaces;

namespace PruebaTransacciones.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AuthControlerr : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthControlerr(IAuthServices authServices) {

            _authServices = authServices;
        }

        [HttpPost("login")]
        public IActionResult login(UserDto user) {
            var isValidateCredencial = _authServices.getUserAndPasword(user.user, user.password);

            if (isValidateCredencial != null) {
                return Ok(new { isValidateCredencial });
            }
            return Unauthorized();  
        }
    }
}
