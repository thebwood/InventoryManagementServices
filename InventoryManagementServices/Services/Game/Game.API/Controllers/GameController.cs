using Game.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Game.API.Services.Interfaces;

namespace Game.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGameService _service;


        public GameController(IGameService service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

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
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(GamesModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGame(Guid? gameId)
        {
            try
            {
                var data = _service.GetGame(gameId);

                var retVal = _mapper.Map<GamesModel>(data);

                if (retVal != null)
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
        [HttpPost("search")]
        [ProducesResponseType(typeof(List<GameSearchResultsModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<GameSearchResultsModel>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(List<GameSearchResultsModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<GameSearchResultsModel>), (int)HttpStatusCode.InternalServerError)]
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
        [ProducesResponseType(typeof(GameRatingsModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GameRatingsModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GameRatingsModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGameRatings()
        {
            try
            {
                var data = _service.GetGameRatings();

                var retVal = _mapper.Map<IEnumerable<GameRatingsModel>>(data);

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
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
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
