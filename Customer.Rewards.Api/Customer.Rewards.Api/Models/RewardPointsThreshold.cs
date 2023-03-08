using Newtonsoft.Json;

namespace Customer.Rewards.Api.Models
{
    public class RewardPointsThreshold
    {
        /// <summary>
        /// The threshold amount
        /// </summary>
        /// <example>50</example>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// The reward points for threshold amount
        /// </summary>
        /// <example>1</example>
        [JsonProperty("points")]
        public int Points { get; set; }
    }
}
