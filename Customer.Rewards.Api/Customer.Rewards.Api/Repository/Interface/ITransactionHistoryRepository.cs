using Customer.Rewards.Api.Models;

namespace Customer.Rewards.Api.Repository.Interface
{
    public interface ITransactionHistoryRepository
    {
        List<TransactionHistory> GetTransactionHistory(long customerId);
    }
}
