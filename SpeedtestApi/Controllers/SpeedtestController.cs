using System;
using Microsoft.AspNetCore.Mvc;
using SpeedtestApi.Models;

namespace SpeedtestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedtestController : ControllerBase
    {
        // POST /speedtest
        [HttpPost]
        public IActionResult Post([FromBody] Speedtest speedtest)
        {
            Console.WriteLine($"I got: { speedtest.User }, { speedtest.Device }, { speedtest.Timestamp }, { speedtest.Data }");

            return Ok();
        }
    }
}