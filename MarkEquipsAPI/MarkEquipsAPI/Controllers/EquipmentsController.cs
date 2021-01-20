using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _entityService;
        //private readonly ILogger<EquipmentsController> _logger;

        public EquipmentsController(//ILogger<EquipmentsController> logger, 
            IEquipmentService entitieService)
        {
            _entityService = entitieService;
            //_logger = logger;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(await _entityService.FindWithPageSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityService.FindAllAsync());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _entityService.FindByIDAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Post(EquipmentDto equipment)
        {
            if (equipment == null) return null;
            await _entityService.CreateAsync(equipment);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Put(EquipmentDto equipment)
        {
            if (equipment == null) return null;
            await _entityService.UpdateAsync(equipment);
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

