using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeedTestApi.Models;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        // POST /SpeedTest
        [HttpPost]
        public IActionResult Post([FromBody] TestResult SpeedTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Console.WriteLine($"I got: { JsonConvert.SerializeObject(SpeedTest) }");

            return Ok();
        }
    }
}