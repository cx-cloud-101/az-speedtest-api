using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeedTestApi.Models;
using SpeedTestApi.Services;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        private readonly ISpeedTestEvents _eventHub;

        public SpeedTestController(ISpeedTestEvents eventHub)
        {
            _eventHub = eventHub;
        }
        
        // POST /SpeedTest
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestResult speedTest)
        {
            await _eventHub.PublishSpeedTest(speedTest);

            return Ok();
        }
    }
}