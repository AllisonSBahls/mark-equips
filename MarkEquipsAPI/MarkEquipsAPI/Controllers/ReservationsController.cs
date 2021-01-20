using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReserverService _entityService;
        public ReservationsController(IReserverService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _entityService.FindAllAsync());
        }

        #nullable enable
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get([FromQuery] string? name, string? equipment, string sortDirection, int pageSize, int page)
        {
            return Ok(await _entityService.FindWithPageSearch(name, equipment, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _entityService.FindByIdAsync(id));
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Post(ReserverDto reserver)
        {
            if (reserver == null) return this.StatusCode(StatusCodes.Status404NotFound);
            await _entityService.AddReserverAsync(reserver);

            return this.StatusCode(StatusCodes.Status200OK);
        }

        [HttpPatch("cancel/{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Patch(int id)
        {
            try { 
            await _entityService.RevokeAsync(id);
            return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Controller Reservations" + e.Message);
            }
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return this.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}


