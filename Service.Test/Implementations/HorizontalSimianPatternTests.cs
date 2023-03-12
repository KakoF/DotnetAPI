using Microsoft.Extensions.Logging;
using Moq;
using Service.Implementations;
using System;
using Xunit;

namespace Service.Test.Implementations
{
    public class HorizontalSimianPatternTests
    {
        private readonly HorizontalSimianPattern _sut;
        private readonly MockRepository _mock;
        private readonly Mock<ILogger<HorizontalSimianPattern>> _mockLogger;



        public HorizontalSimianPatternTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockLogger = _mock.Create<ILogger<HorizontalSimianPattern>>();
            _sut = new HorizontalSimianPattern(_mockLogger.Object);
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
