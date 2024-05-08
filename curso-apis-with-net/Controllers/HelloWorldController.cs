using curso_apis_with_net.Services;
using Microsoft.AspNetCore.Mvc;

namespace curso_apis_with_net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            _logger.LogDebug("Retorna el hello world");
            return Ok(_helloWorldService.GetHelloWorld());
        }
    }
}
