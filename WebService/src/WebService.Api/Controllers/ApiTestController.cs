using Microsoft.AspNetCore.Mvc;

namespace WebService.Api.Controllers;

[ApiController]
[Route("/api")]
public class ApiTestController : ControllerBase
{
    private readonly ILogger<ApiTestController> _logger;

    public ApiTestController(ILogger<ApiTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {
        _logger.LogInformation("[{}] Logger is working! Path: {}", DateTime.UtcNow, Request.Path);

        var apiTestDto = new
        {
            Message = $"API is working! Path: {Request.Path}",
            Date = DateTime.UtcNow,
            DotnetVersion = Environment.Version
        };

        return Ok(await Task.FromResult(apiTestDto));
    }
}
