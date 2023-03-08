using Customer.Rewards.Api.Response;

namespace Customer.Rewards.Api.Managers.Interface
{
    public interface ICustomerRewardsManager
    {
        RewardPointsResponse GetCustomerRewardsById(long customerId);
    }
}
