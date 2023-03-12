using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Service.Implementations;
using System;
using Xunit;

namespace Service.Test.Implementations
{
    public class DiagonalSimianPatternTests
    {
        private readonly DiagonalSimianPattern _sut;
        private readonly MockRepository _mock;
        private readonly Mock<ILogger<DiagonalSimianPattern>> _mockLogger;
        


        public DiagonalSimianPatternTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockLogger = _mock.Create<ILogger<DiagonalSimianPattern>>();
            _sut = new DiagonalSimianPattern(_mockLogger.Object);
        }

        [Fact]
        public void CheckPattern_Should_Retunr_One_True_In_Array()
        {

            // Arrange
            string[] dna = new string[] {
                "CTGAGA", "CTATGC", "TATTGT", "AGAGGG", "CCCCTA", "TCACTG"
            };
            
            // Act
            var result = _sut.CheckPattern(dna);

            // Assert
            Assert.Contains(true, result);
        }

        [Fact]
        public void CheckPattern_Should_Retunr_One_False_In_Array()
        {

            // Arrange
            string[] dna = new string[] {
                "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG"
            };

            // Act
            var result = _sut.CheckPattern(dna);

            // Assert
            Assert.Contains(false, result);
        }
    }
}
