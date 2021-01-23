using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _entityService;
        public SchedulesController(IScheduleService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Collaborator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get()
        {
            return Ok( await _entityService.FindAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _entityService.FindByIDAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Post(ScheduleDto schedule)
        {
            if (schedule == null) return null;
            await _entityService.CreateAsync(schedule);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Put(ScheduleDto schedule)
        {
            if (schedule == null) return null;
            await _entityService.UpdateAsync(schedule);
            return this.StatusCode(StatusCodes.Status200OK);

        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
