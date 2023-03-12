using Domain.DTO.IsSimianDTO;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.DTO.SimianDTO;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using SimianApplication.Controllers;
using System;

using System.Threading.Tasks;
using Xunit;

namespace SimianApplication.Test.Controllers
{
    public class SimianControllerTests
    {
        private readonly SimianController _sut;
        private readonly MockRepository _mock;
        private readonly Mock<ISimianService> _mockSimianService;

        public SimianControllerTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockSimianService = _mock.Create<ISimianService>();
            _sut = new SimianController(_mockSimianService.Object);
        }

        [Fact]
        public async Task Post_Expected_Return_True_Dna_Result()
        {
            // Arrange
            string[] dna = new string[] {
                "CTGAGA", "CTATGC", "TATTGT", "AGAGGG", "CCCCTA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            _mockSimianService.Setup(c => c.VerifyDnaAsync(data)).ReturnsAsync(new IsSimianResponseDTO(true));

            // Act
            var result = await _sut.Post(data);

            // Assert
            Assert.True(result.IsSimian);
            _mockSimianService.Verify(c => c.VerifyDnaAsync(data), Times.Once);
        }

        [Fact]
        public async Task Post_Expected_Return_False_Dna_Result()
        {
            // Arrange
            string[] dna = new string[] {
                "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            _mockSimianService.Setup(c => c.VerifyDnaAsync(data)).ReturnsAsync(new IsSimianResponseDTO(false));

            // Act
            var result = await _sut.Post(data);

            // Assert
            Assert.False(result.IsSimian);
            _mockSimianService.Verify(c => c.VerifyDnaAsync(data), Times.Once);
        }

        [Fact]
        public async Task Get_Expected_Return_Simian_Result()
        {
            // Arrange
            int id = 1;
            _mockSimianService.Setup(c => c.Get(id)).ReturnsAsync(new SimianResponseDTO(1, "ATGCGA", false));

            // Act
            var result = await _sut.Get(id);

            // Assert
            Assert.Equal(1, result.Id);
            _mockSimianService.Verify(c => c.Get(id), Times.Once);
        }

        [Fact]
        public async Task Get_Expected_Return_Null_Result_Add_Notification()
        {
            // Arrange
            int id = 99;
            _mockSimianService.Setup(c => c.Get(id)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.Get(id);

            // Assert
            Assert.Null(result);
            _mockSimianService.Verify(c => c.Get(id), Times.Once);
        }
    }
}
