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

        [HttpPost]
        public async Task<IActionResult> Post(Reserver reserver)
        {
            if (reserver == null) return null;
            return Ok( await _entityService.AddReserverAsync(reserver));
        }
    }
}


