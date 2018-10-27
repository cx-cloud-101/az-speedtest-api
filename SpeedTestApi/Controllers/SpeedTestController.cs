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
        private readonly IAuthorization _authorization;

        public SpeedTestController(ISpeedTestEvents eventHub, IAuthorization authorization)
        {
            _eventHub = eventHub;
            _authorization = authorization;
        }
        
        // POST /SpeedTest
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestResult speedTest)
        {
            if (speedTest.User != _authorization.AuthorizedUser)
            {
                return Unauthorized();
            }
            
            await _eventHub.PublishSpeedTest(speedTest);

            return Ok();
        }
    }
}