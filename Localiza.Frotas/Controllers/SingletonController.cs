using Localiza.Frotas.infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer singletonContainer;

        public SingletonController(SingletonContainer singletonContainer)
        {
            this.singletonContainer = singletonContainer;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            // var singleton = singletonContainer;
            return Ok(singletonContainer);


        }
    }
}
