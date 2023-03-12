using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Moq;
using SimianApplication.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SimianApplication.Test.Controllers
{
    public class StatsControllerTests
    {
        private readonly StatsController _sut;
        private readonly MockRepository _mock;
        private readonly Mock<IStatsService> _mockStatsService;

        public StatsControllerTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockStatsService = _mock.Create<IStatsService>();
            _sut = new StatsController(_mockStatsService.Object);
        }

        [Fact]
        public async Task Get_Expected_Return_Stats_Result()
        {
            // Arrange
            _mockStatsService.Setup(c => c.GetStatsAsync()).ReturnsAsync(new StatsResponseDTO(1, 2, (decimal)0.5));

            // Act
            var result = await _sut.Get();

            // Assert
            Assert.Equal(1, result.CountSimianDna);
            Assert.Equal(2, result.CountHumanDna);
            Assert.Equal((decimal)0.5, result.Ratio);
            _mockStatsService.Verify(c => c.GetStatsAsync(), Times.Once);
        }
    }
}
