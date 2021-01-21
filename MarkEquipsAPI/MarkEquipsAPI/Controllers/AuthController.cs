using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] CollaboratorDto user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenDto tokenDto)
        {
            if (tokenDto is null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(tokenDto);
            if (token == null) return BadRequest("Invalid request");
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var user = User.Identity.Name;
            var result = _loginService.RevokeToken(user);
            if (!result) return BadRequest("Invalid request");
            return NoContent();
        }
    }
}
