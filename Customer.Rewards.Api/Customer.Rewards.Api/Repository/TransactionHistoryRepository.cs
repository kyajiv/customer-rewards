using Customer.Rewards.Api.Exceptions;
using Customer.Rewards.Api.Models;
using Customer.Rewards.Api.Repository.Interface;
using Newtonsoft.Json;

namespace Customer.Rewards.Api.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        public List<TransactionHistory> GetTransactionHistory(long customerId)
        {
            if (customerId < 1)
            {
                throw new InvalidCustomerIdException("Invalid customer id");
            }

            // Pull transaction history data from TransactionHistory.json
            using (var r = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/TransactionHistory.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<TransactionHistory>>(json);
                return items?.Where(c => c.CustomerId == customerId)?.ToList();
            }
        }
    }
}
