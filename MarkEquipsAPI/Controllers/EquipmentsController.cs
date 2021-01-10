using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkEquipsAPI.Services.Implementations;
using MarkEquipsAPI.Models;

namespace MarkEquipsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly ILogger<EquipmentsController> _logger;
        private readonly IEntitieServices _entitiesServices;
        public EquipmentsController(ILogger<EquipmentsController> logger, IEntitieServices entitieServices)
        {
            _entitiesServices = entitieServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_entitiesServices.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var equip = _entitiesServices.FindById(id);
            if (equip == null) return NotFound();
            return Ok(equip);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Equipment equip)
        {
            if (equip == null) return BadRequest();
            return Ok(_entitiesServices.Create(equip));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Equipment equip)
        {
            if (equip == null) return BadRequest();
            return Ok(_entitiesServices.Update(equip));
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _entitiesServices.Delete(id);
            return NoContent();
        }
    }
}
