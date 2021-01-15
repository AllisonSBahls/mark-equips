using MarkEquipsAPI.Data.DTO;
using MarkEquipsAPI.Services;
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
        public async Task<IActionResult> Get()
        {
            return Ok( await _entityService.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _entityService.FindByIDAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ScheduleDto schedule)
        {
            if (schedule == null) return null;
            await _entityService.CreateAsync(schedule);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        public async Task<IActionResult> Put(ScheduleDto schedule)
        {
            if (schedule == null) return null;
            await _entityService.UpdateAsync(schedule);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
