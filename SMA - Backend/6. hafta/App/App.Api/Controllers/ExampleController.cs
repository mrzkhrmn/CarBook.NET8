using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet("{num1}")]
        public IActionResult Get([FromRoute]int num1, [FromQuery]int num2, [FromHeader]int num3)
        {
            int result = (num1 - num2) * num3;

            return Ok(result);
        }
    }
}
