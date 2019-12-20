using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthquakeSite.DTOs;
using EarthquakeSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EarthquakeSite.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await authService.Authenticate(authDTO.Login, authDTO.Password);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> Registrate(AuthDTO authDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await authService.Registrate(authDTO.Login, authDTO.Password);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}