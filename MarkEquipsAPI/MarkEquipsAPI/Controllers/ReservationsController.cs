using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Models.Enums;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityService.FindAllAsync());
        }

#nullable enable
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get(
            [FromQuery] string? name,
            [FromQuery] string? equipment,
            [FromQuery] DateTime? date,
            [FromQuery] string? status,
            string sortDirection,
            int pageSize,
            int page)
        {

            int statusId = !string.IsNullOrWhiteSpace(status) ? int.Parse(status) : 0;
            return Ok(await _entityService.FindWithPageSearch(name, equipment, sortDirection, pageSize, page, date, statusId));
        }

        [HttpGet("my/{sortDirection}/{pageSize}/{page}")]
        [Authorize]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get([FromQuery] string? equipment, [FromQuery] DateTime? date, [FromQuery] string? status, string sortDirection, int pageSize, int page)
        {
            int statusId = !string.IsNullOrWhiteSpace(status) ? int.Parse(status) : 0;
            return Ok(await _entityService.FindWithPageSearchForUser(equipment, sortDirection, pageSize, page, date, statusId));
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
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Patch(int id)
        {
            try
            {
                await _entityService.RevokeAsync(id);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Controller Reservations" + e.Message);
            }
        }

        [HttpPatch("deliver/{id}")]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> PutDeliver(int id)
        {
            try
            {
                await _entityService.DeliverAsync(id);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Controller Reservations" + e.Message);
            }
        }

        [HttpPatch("collect/{id}")]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> PatchTake(int id)
        {
            try
            {
                await _entityService.TakeAsync(id);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Controller Reservations" + e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return this.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}


