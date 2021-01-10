using MarkEquipsAPI.Models;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEntitieService _entitieService;
        private readonly ILogger<EquipmentsController> _logger;

        public EquipmentsController(ILogger<EquipmentsController> logger, IEntitieService entitieService)
        {
            _entitieService = entitieService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_entitieService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var equip = _entitieService.FindByID(id);
            if (equip == null) return NotFound();
            return Ok(equip);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Equipment equip)
        {
            if (equip == null) return BadRequest();
            return Ok(_entitieService.Create(equip));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Equipment equip)
        {
            if (equip == null) return BadRequest();
            return Ok(_entitieService.Update(equip));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _entitieService.Delete(id);
            return NoContent();
        }
    }
}
