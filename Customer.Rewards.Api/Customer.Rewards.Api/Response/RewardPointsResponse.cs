namespace Customer.Rewards.Api.Response
{
    public class RewardPointsResponse
    {
        /// <summary>
        /// The total reward points for a given customer
        /// </summary>
        /// <example>3</example>
        public int TotalRewardPoints { get; set; }

        /// <summary>
        /// The monthwise earned reward points for a given customer
        /// </summary>
        public List<MonthlyRewardPointsResponse> MonthlyRewardPoints { get; set; }
    }
}
