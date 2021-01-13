using MarkEquipsAPI.Models;
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
    public class ReservationsController : ControllerBase
    {
        private readonly IReserverService _entityService;
        public ReservationsController(IReserverService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _entityService.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _entityService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Reserver reserver)
        {
            if (reserver == null) return this.StatusCode(StatusCodes.Status404NotFound);
            await _entityService.AddReserverAsync(reserver);

            return this.StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try { 
            await _entityService.RevokeAsync(id);
            return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Controller Reserver" + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return this.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}


