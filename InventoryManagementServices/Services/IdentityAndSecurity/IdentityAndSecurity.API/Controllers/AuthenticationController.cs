using IdentityAndSecurity.API.Models;
using IdentityAndSecurity.API.Services.Interfaces;
using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : InventoryManagementController<AuthenticationController>
    {
        private IUserService _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService service) : base(logger)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<UserRegisterResponseModel> Register(UserRegisterModel request)
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
        public ActionResult<UserLoginResponseModel> Login(UserLoginModel request)
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
