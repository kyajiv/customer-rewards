using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Repository.Interface;
using Customer.Rewards.Api.Response;

namespace Customer.Rewards.Api.Managers
{
    public class CustomerRewardsManager : ICustomerRewardsManager
    {
        private ITransactionHistoryRepository transactionHistoryRepository;
        
        public CustomerRewardsManager(ITransactionHistoryRepository transactionHistoryRepository) 
        {
            this.transactionHistoryRepository = transactionHistoryRepository;
        }

        public RewardPointsResponse GetCustomerRewardsById(long customterId)
        {
            throw new NotImplementedException();
        }
    }
}
