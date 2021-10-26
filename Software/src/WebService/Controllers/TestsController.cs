using Microsoft.AspNetCore.Mvc;
using WebService.Dtos;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestsController : ControllerBase
    {
        [HttpGet("test")]
        public ActionResult<MessageDto> Test()
        {
            var messageDto = new MessageDto
            {
                Content = $"API is working! Path: {HttpContext.Request.Path}"
            };

            return Ok(messageDto);
        }
    }
}
