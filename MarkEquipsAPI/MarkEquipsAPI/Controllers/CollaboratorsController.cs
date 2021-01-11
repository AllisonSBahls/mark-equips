using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
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
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _entityService;
        public CollaboratorsController(ICollaboratorService entityService)
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
        public IActionResult Post(Collaborator collaborator)
        {
            if (collaborator == null) return null;
            return Ok(_entityService.Create(collaborator));
        }
        
        [HttpPut]
        public IActionResult Put(Collaborator collaborator)
        {
            if (collaborator == null) return null;
            return Ok(_entityService.Update(collaborator));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _entityService.Delete(id);
            return NoContent();
        }
    }
}
