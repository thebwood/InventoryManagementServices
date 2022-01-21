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

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}
