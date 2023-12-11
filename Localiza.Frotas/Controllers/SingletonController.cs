using Localiza.Frotas.infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            var singleton = new Singleton();
            return Ok(singleton);
        }
    }
}
