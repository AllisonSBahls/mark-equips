using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Helpers;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.FindByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"error {ex.Message}");
            }
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Get([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(await _service.FindWithPageSearch(name, sortDirection, pageSize, page));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Put(UserDto user)
        {
            try { 
            await _service.UpdateAsync(user);
            return this.StatusCode(StatusCodes.Status200OK, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"error {ex.Message}");
            }
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            if (userDto == null) return this.StatusCode(StatusCodes.Status400BadRequest);
            var result = await _service.CreateAsync(userDto);
            Console.WriteLine(result);
            if(result == null)
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);   
            }
            return this.StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try { 
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"error {ex.Message}");
            }
        }
    }
}
