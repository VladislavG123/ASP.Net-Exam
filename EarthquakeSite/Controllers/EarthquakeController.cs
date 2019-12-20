using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthquakeSite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EarthquakeSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EarthquakeController : ControllerBase
    {
        private readonly IEarthquakeService earthquakeService;

        public EarthquakeController(IEarthquakeService earthquakeService)
        {
            this.earthquakeService = earthquakeService;
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 60)]
        public async Task<IActionResult> GetEarthquakes(int count)
        {
            var response = await earthquakeService.GetEarthquakes(count);

            return Ok(new { Place = response });
        }
    }
}