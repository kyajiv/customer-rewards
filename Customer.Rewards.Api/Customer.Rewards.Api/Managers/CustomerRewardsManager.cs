using Customer.Rewards.Api.Exceptions;
using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Models;
using Customer.Rewards.Api.Repository.Interface;
using Customer.Rewards.Api.Response;
using Newtonsoft.Json;

namespace Customer.Rewards.Api.Managers
{
    public class CustomerRewardsManager : ICustomerRewardsManager
    {
        private ITransactionHistoryRepository transactionHistoryRepository;
        
        public CustomerRewardsManager(ITransactionHistoryRepository transactionHistoryRepository) 
        {
            this.transactionHistoryRepository = transactionHistoryRepository;
        }

        public RewardPointsResponse GetCustomerRewardsById(long customerId)
        {
            if (customerId < 1)
            {
                throw new InvalidCustomerIdException("Invalid customer id");
            }

            var transactions = transactionHistoryRepository.GetTransactionHistory(customerId);
            if(transactions == null || transactions.Count == 0)
            {
                return null;
            }


            var response = new RewardPointsResponse();     
            
            // group by Month, year to get points earned in each month
            response.MonthlyRewardPoints = transactions.Select(c => new { MonthYear = c.TransactionDate.ToString("MMM, yyyy"), Points = CalculatePoints(c.Amount) }).Where(c => c.Points > 0)
                .GroupBy(c => c.MonthYear).Select(c => new MonthlyRewardPointsResponse { MonthYear = c.Key, TotalRewardPoints = c.Sum(p => p.Points) }).ToList();
            
            response.TotalRewardPoints = response.MonthlyRewardPoints.Sum(p => p.TotalRewardPoints);

            return response;
        }

        private int CalculatePoints(decimal amount)
        {
            // reward point threshold amounts are configurable in RewardPointsThreshold.json file
            using (var r = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/RewardPointsThreshold.json"))
            {
                string json = r.ReadToEnd();
                var rewardPointsThresholdList = JsonConvert.DeserializeObject<List<RewardPointsThreshold>>(json);

                var total = 0;
                foreach(var item in rewardPointsThresholdList)
                {
                    total += ((int)Math.Max(amount - item.Amount, 0)) * item.Points;
                }

                return total;
            }
        }
    }
}
