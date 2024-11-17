using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("{input}")]
        public IActionResult GetMessage([FromRoute]string input)
        {
            return Ok($"Hello {input}");
        }
    }
}