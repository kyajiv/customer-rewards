using Customer.Rewards.Api.Controllers;
using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Response;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Customer.Rewards.Api.Tests.Controllers
{
    public class CustomerRewardsControllerTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ICustomerRewardsManager> mockCustomerRewardsManager;
        private readonly Mock<ILogger<CustomerRewardsController>> mockLogger;

        public CustomerRewardsControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockCustomerRewardsManager = mockRepository.Create<ICustomerRewardsManager>();
            mockLogger = mockRepository.Create<ILogger<CustomerRewardsController>>();
        }

        [Fact]
        public void GetCustomerRewards_Returns_Rewards()
        {
            // Arrange
            long customerId = 1;
            mockCustomerRewardsManager.Setup(c => c.GetCustomerRewardsById(customerId)).Returns(
                new RewardPointsResponse
                {
                    TotalRewardPoints = 100,
                    MonthlyRewardPoints = new List<MonthlyRewardPointsResponse> { new MonthlyRewardPointsResponse { TotalRewardPoints = 100, MonthYear = "Jan, 2023" } }
                }
                );

            var controller = new CustomerRewardsController(mockLogger.Object, mockCustomerRewardsManager.Object);

            // Act
            var result = controller.Get(customerId);

            // Assert
            mockRepository.VerifyAll();
            Assert.NotNull(result);
            Assert.Equal(100, result.TotalRewardPoints);
            Assert.Single(result.MonthlyRewardPoints);
        }
    }
}
