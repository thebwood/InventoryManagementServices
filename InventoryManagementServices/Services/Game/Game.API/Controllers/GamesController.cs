using Game.Core.Services.Interfaces;
using Game.Core.Models;
using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Game.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : InventoryManagementController<GamesController>
    {

        private readonly IGameService _service;


        public GamesController(ILogger<GamesController> logger, IGameService service) : base(logger)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGames()
        {
            try
            {
                var retVal = _service.GetGames();

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetGames", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGame(Guid? gameId)
        {
            try
            {
                var retVal = _service.GetGame(gameId);

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetGame by ID", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }
        [HttpPost("search")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult SearchGames([FromBody] GameSearchModel searchRequest)
        {

            try
            {
                var searchResults = _service.SearchGames(searchRequest);

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }

        }


        [HttpGet("ratings")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGameRatings()
        {
            try
            {
                var retVal = _service.GetGameRatings();

                if (retVal.Count() > 0)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateGame([FromBody] GamesModel game)
        {
            var errorList = new List<string>();

            try
            {
                errorList = _service.SaveDetail(game);
                if (errorList.Count > 0)
                {
                    return BadRequest(errorList);
                }
            }
            catch (Exception ex)
            {
                errorList = new List<string>() { "Error in saving" };
                return BadRequest(errorList);
            }

            return Ok(errorList);
        }


    }
}
