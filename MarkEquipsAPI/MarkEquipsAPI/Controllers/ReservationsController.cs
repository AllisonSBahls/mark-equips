using MarkEquipsAPI.Models;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Get()
        {
            return Ok(_entityService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _entityService.FindByID(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Reserver reserver)
        {
            if (reserver == null) return null;
            return Ok(_entityService.Create(reserver));
        }
        
        [HttpPut]
        public IActionResult Put(Reserver reserver)
        {
            if (reserver == null) return null;
            return Ok(_entityService.Update(reserver));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _entityService.Delete(id);
            return NoContent();
        }
    }
}
