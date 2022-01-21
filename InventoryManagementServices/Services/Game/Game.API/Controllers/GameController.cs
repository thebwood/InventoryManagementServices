using Game.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Game.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGames()
        {
            try
            {
                var data = _service.GetGames();

                var retVal = _mapper.Map<IEnumerable<GamesModel>>(data);

                if (retVal != null)
                {
                    return Ok(retVal);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}
