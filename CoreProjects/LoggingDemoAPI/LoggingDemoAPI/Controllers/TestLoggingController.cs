using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestLoggingController : ControllerBase
    {
        private readonly ILogger<TestLoggingController> _logger;

        public TestLoggingController(ILogger<TestLoggingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("log-test")]
        public IActionResult LogTest()
        {
            _logger.LogTrace("This is a TRACE log.");
            _logger.LogDebug("This is a DEBUG log.");
            _logger.LogInformation("This is an INFO log.");
            _logger.LogWarning("This is a WARNING log.");
            _logger.LogError("This is an ERROR log.");
            _logger.LogCritical("This is a CRITICAL log.");

            return Ok("Logs have been written using EventSource, EventLog, and TraceSource!");
        }
    }
}
