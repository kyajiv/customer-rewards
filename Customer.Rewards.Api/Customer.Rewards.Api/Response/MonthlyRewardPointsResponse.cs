namespace Customer.Rewards.Api.Response
{
    public class MonthlyRewardPointsResponse
    {
        /// <summary>
        /// The total earned reward points in a month for a given customer
        /// </summary>
        ///<example>3</example>
        public int TotalRewardPoints { get; set; }

        /// <summary>
        /// The month year of reward points earned
        /// </summary>
        ///<example>Jan, 2023</example>
        public string MonthYear { get; set; }
    }
}
