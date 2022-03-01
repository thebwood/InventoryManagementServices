using AutoMapper;
using InventoryManagement.Web.Base.Controllers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefData.API.Models;
using RefData.API.Services.Interfaces;
using System.Net;

namespace RefData.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RefDataController : InventoryManagementController<RefDataController>
    {
        private IRefDataService _service;
        private readonly IMapper _mapper;
        public RefDataController(ILogger<RefDataController> logger, IRefDataService service, IMapper mapper) : base(logger)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("genres")]
        [ProducesResponseType(typeof(List<GenreModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<GenreModel>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<GenreModel>), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetGenres()
        {
            try
            {
                var data = _service.GetGenres();

                var retVal = _mapper.Map<List<GenreModel>>(data);

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

    }
}
