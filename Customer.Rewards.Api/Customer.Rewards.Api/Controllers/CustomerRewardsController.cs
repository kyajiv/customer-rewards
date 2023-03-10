using Customer.Rewards.Api.Exceptions;
using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Rewards.Api.Controllers
{
    [ApiController]
    [Route("customer-rewards")]
    public class CustomerRewardsController : ControllerBase
    {
        private readonly ILogger<CustomerRewardsController> logger;
        private readonly ICustomerRewardsManager customerRewardsManager;

        public CustomerRewardsController(ILogger<CustomerRewardsController> logger, ICustomerRewardsManager customerRewardsManager)
        {
            this.logger = logger;
            this.customerRewardsManager = customerRewardsManager;
        }

        /// <summary>
        /// Get customer reward points
        /// </summary>
        /// <param name="customerId">The unique customer id</param>
        /// <returns>Reward Points Response</returns>
        /// <exception cref="InvalidCustomerIdException">Invalid customer id exception</exception>
        [HttpGet]
        public RewardPointsResponse Get(long customerId)
        {
            if (customerId < 1)
            {
                logger.LogWarning($"Invalid customer id received - {customerId}");
                throw new InvalidCustomerIdException("Invalid customer id");
            }

            var rewardResponse = customerRewardsManager.GetCustomerRewardsById(customerId);
            return rewardResponse;
        }
    }
}