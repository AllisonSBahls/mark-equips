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
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _entityService;
        public SchedulesController(IScheduleService entityService)
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
        public IActionResult Post(Schedule schedule)
        {
            if (schedule == null) return null;
            return Ok(_entityService.Create(schedule));
        }
        
        [HttpPut]
        public IActionResult Put(Schedule schedule)
        {
            if (schedule == null) return null;
            return Ok(_entityService.Update(schedule));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _entityService.Delete(id);
            return NoContent();
        }
    }
}
