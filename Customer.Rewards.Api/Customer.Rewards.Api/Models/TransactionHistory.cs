using Newtonsoft.Json;

namespace Customer.Rewards.Api.Models
{
    public class TransactionHistory
    {
        /// <summary>
        /// The unique transaction id
        /// </summary>
        /// <example>1</example>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The transaction date
        /// </summary>
        /// <example>2023-01-13T00:00:00</example>
        [JsonProperty("transactionDate")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// The unique customer id
        /// </summary>
        /// <example>1</example>
        [JsonProperty("customerId")]
        public long CustomerId { get; set; }

        /// <summary>
        /// The transaction amount
        /// </summary>
        /// <example>100.0</example>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
