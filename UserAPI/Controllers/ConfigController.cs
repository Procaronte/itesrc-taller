using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Configurations;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly AppInfo _appInfo;

        public ConfigController(AppInfo appInfo)
        {
            _appInfo = appInfo;
        }

        [HttpGet]
        public IActionResult GetConfigValue()
        {
            return Ok(_appInfo);
        }
    }
}
