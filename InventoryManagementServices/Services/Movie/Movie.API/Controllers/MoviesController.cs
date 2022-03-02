using Movie.Core.Services.Interfaces;
using Movie.Core.Models;
using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Movie.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : InventoryManagementController<MoviesController>
    {
        private IMovieService _service;
        public MoviesController(ILogger<MoviesController> logger, IMovieService service) : base(logger)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovies()
        {
            try
            {
                var retVal = _service.GetMovies();

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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult SearchMovies([FromBody] MovieSearchModel searchRequest)
        {
            try
            {
                var searchResults = _service.SearchMovies(searchRequest);

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }

        }

        [HttpGet("{movieId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovie(Guid? movieId)
        {
            try
            {
                var retVal = _service.GetMovie(movieId);

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


        [HttpGet("ratings")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovieRatings()
        {
            try
            {
                var retVal = _service.GetMovieRatings();

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

        [HttpGet("genres")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovieGenres()
        {
            try
            {
                var retVal = _service.GetMovieGenres();

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
        public IActionResult UpdateMovie([FromBody] MoviesModel movie)
        {
            var errorList = new List<string>();

            try
            {

                errorList = _service.SaveDetail(movie);
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
