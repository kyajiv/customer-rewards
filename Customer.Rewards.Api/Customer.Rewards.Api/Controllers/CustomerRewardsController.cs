using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Rewards.Api.Controllers
{
    [ApiController]
    [Route("customer-rewards")]
    public class CustomerRewardsController : ControllerBase
    {
        private readonly ILogger<CustomerRewardsController> _logger;
        private readonly ICustomerRewardsManager customerRewardsManager;

        public CustomerRewardsController(ILogger<CustomerRewardsController> logger, ICustomerRewardsManager customerRewardsManager)
        {
            _logger = logger;
            this.customerRewardsManager = customerRewardsManager;
        }

        [HttpGet]
        public RewardPointsResponse Get(long customerId)
        {
            var rewardResponse = customerRewardsManager.GetCustomerRewardsById(customerId);
            return rewardResponse;
        }
    }
}