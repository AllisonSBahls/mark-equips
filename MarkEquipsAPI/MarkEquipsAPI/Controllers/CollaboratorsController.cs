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
    [Authorize("Bearer")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _entityService;
        public CollaboratorsController(ICollaboratorService entityService)
        {
            _entityService = entityService;
        }


        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(await _entityService.FindWithPageSearch(name, sortDirection, pageSize, page));
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
        public async Task<IActionResult> Post(CollaboratorDto collaborator)
        {
            if (collaborator == null) return null;
            await _entityService.CreateAsync(collaborator);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]

        public async Task<IActionResult> Put(CollaboratorDto collaborator)
        {
            if (collaborator == null) return null;
            await _entityService.UpdateAsync(collaborator);
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return NoContent();
        }
    }
}

