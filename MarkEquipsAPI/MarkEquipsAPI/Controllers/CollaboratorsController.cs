using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityService.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _entityService.FindByIDAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Collaborator scollaborator)
        {
            if (scollaborator == null) return null;
            await _entityService.CreateAsync(scollaborator);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        public async Task<IActionResult> Put(Collaborator scollaborator)
        {
            if (scollaborator == null) return null;
            await _entityService.UpdateAsync(scollaborator);
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

