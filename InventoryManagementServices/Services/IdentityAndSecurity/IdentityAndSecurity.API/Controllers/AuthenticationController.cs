using IdentityAndSecurity.API.Models;
using IdentityAndSecurity.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserService _service;

        public AuthenticationController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<UserRegistrationModel> Register(UserModel request)
        {
            var response = _service.Register(request);
            if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<UserLoginModel> Login(UserModel request)
        {
            var response = _service.Login(request);
            if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
