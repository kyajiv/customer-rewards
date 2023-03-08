using Microsoft.AspNetCore.Mvc;

namespace Customer.Rewards.Api.Controllers
{
    [ApiController]
    [Route("health-check")]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Health check
        /// </summary>
        /// <returns>"Healthy" response</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }
    }
}
