using ConfigDemoApi_Assignment9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigDemoApi_Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MySettings _mySettings;

        public ConfigController(IConfiguration configuration, IOptions<MySettings> options)
        {
            _configuration = configuration;
            _mySettings = options.Value;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            // Read manually
            var manualSettings = new
            {
                ApplicationName = _configuration["MySettings:ApplicationName"],
                Version = _configuration["MySettings:Version"],
                MaxItems = _configuration.GetValue<int>("MySettings:MaxItems")
            };

            // Read via Options Pattern (strongly typed)
            var optionsSettings = _mySettings;

            return Ok(new
            {
                ManualConfig = manualSettings,
                OptionsConfig = optionsSettings
            });
        }
    }
}
