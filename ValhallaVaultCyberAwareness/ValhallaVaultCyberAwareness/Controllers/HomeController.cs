using Microsoft.AspNetCore.Mvc;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("Exception in HomeController.");
        }
    }
}
