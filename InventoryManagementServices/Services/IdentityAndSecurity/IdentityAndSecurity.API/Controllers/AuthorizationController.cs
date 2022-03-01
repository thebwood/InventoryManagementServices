using IdentityAndSecurity.API.Services.Interfaces;
using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : InventoryManagementController<AuthorizationController>
    {
        private IUserService _service;
        public AuthorizationController(ILogger<AuthorizationController> logger, IUserService service) : base(logger)
        {
            _service = service;
        }
    }
}
