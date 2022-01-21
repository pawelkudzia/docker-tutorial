using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApiTestController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var apiTestDto = new
            {
                Message = $"API is working! Path: {Request.Path}",
                Date = DateTime.UtcNow,
                DotnetVersion = Environment.Version
            };

            return Ok(await Task.FromResult(apiTestDto));
        }
    }
}