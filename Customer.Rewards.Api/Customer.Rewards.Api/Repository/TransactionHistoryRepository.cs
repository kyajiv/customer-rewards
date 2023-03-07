using Customer.Rewards.Api.Models;
using Customer.Rewards.Api.Repository.Interface;

namespace Customer.Rewards.Api.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        public List<TransactionHistory> GetTransactionHistory(long customerId)
        {
            throw new NotImplementedException();
        }
    }
}
