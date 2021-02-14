using MarkEquipsAPI.Data.DTOs;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto userDto)
        {
            try
            {
                var user = await _service.LoginAsync(userDto);
                if (user != null) return Created("User", user);
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"error {ex.Message}");
            }
        }

        [HttpGet("validate")]
        [AllowAnonymous]
        public IActionResult Get([FromHeader]string token)
        {
            try { 
            bool result = _service.ValidateToken(token);

                if (result) { 
                    return this.StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    return this.StatusCode(StatusCodes.Status204NoContent, result);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

        }
    }
}
