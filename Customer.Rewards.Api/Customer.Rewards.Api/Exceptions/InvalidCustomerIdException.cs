namespace Customer.Rewards.Api.Exceptions
{
    public class InvalidCustomerIdException : Exception
    {
        public InvalidCustomerIdException(string message) : base(message) { }
    }
}
