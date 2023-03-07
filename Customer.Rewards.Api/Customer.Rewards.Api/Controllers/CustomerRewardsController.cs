using Customer.Rewards.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Rewards.Api.Controllers
{
    [ApiController]
    [Route("customer-rewards")]
    public class CustomerRewardsController : ControllerBase
    {
        private readonly ILogger<CustomerRewardsController> _logger;

        public CustomerRewardsController(ILogger<CustomerRewardsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RewardPointsResponse Get()
        {
            throw new NotImplementedException();
        }
    }
}