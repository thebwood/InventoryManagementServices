using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : InventoryManagementController<InventoryController>
    {
        public InventoryController(ILogger<InventoryController> logger) : base(logger)
        {
        }
    }
}
