using Customer.Rewards.Api.Exceptions;
using Customer.Rewards.Api.Managers;
using Customer.Rewards.Api.Models;
using Customer.Rewards.Api.Repository.Interface;
using Moq;
using Xunit;

namespace Customer.Rewards.Api.Tests.Managers
{
    public class CustomerRewardsManagerTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ITransactionHistoryRepository> mockTransactionHistoryRepository;

        public CustomerRewardsManagerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockTransactionHistoryRepository = mockRepository.Create<ITransactionHistoryRepository>();
        }

        [Fact]
        public void GetCustomerRewardsById_Returns_Rewards()
        {
            // Arrange
            long customerId = 1;
            mockTransactionHistoryRepository.Setup(c => c.GetTransactionHistory(customerId)).Returns(
                new List<TransactionHistory>
                {
                    new TransactionHistory { Id = 1, Amount = 10, CustomerId = 1, TransactionDate = new DateTime(2023, 1, 1) },
                    new TransactionHistory { Id = 3, Amount = 200, CustomerId = 1, TransactionDate = new DateTime(2023, 2, 2) },
                }
                );

            var manager = new CustomerRewardsManager(mockTransactionHistoryRepository.Object);

            // Act
            var result = manager.GetCustomerRewardsById(
                customerId);

            // Assert
            mockRepository.VerifyAll();
            Assert.NotNull(result);
            Assert.Equal(250, result.TotalRewardPoints);
        }

        [Fact]
        public void GetCustomerRewardsById_Throw_Exception()
        {
            // Arrange
            long customerId = -1;
            var manager = new CustomerRewardsManager(mockTransactionHistoryRepository.Object);

            // Act
            Assert.Throws<InvalidCustomerIdException>(() => manager.GetCustomerRewardsById(customerId));
        }
    }
}
