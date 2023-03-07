namespace Customer.Rewards.Api.Response
{
    public class RewardPointsResponse
    {
        public int TotalRewardPoints { get; set; }
        public List<MonthlyRewardPointsResponse> MonthlyRewardPoints { get; set; }
    }
}
