namespace Customer.Rewards.Api.Models
{
    public class TransactionHistory
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
