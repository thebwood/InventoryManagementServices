using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : InventoryManagementController<PeopleController>
    {
        public PeopleController(ILogger<PeopleController> logger) : base(logger)
        {
        }
    }
}
