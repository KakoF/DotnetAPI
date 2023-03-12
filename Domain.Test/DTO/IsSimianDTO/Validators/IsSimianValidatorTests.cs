using Domain.DTO.IsSimianDTO;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace Domain.Test.DTO.IsSimianDTO.Validators
{
    public class IsSimianValidatorTests
    {
        private IsSimianValidator _sut;
        private MockRepository _mock;
        private readonly Mock<ISimianRepository> _mockSimianRepository;

        public IsSimianValidatorTests()
        {
            _mock = new MockRepository(MockBehavior.Strict);
            _mockSimianRepository = _mock.Create<ISimianRepository>();
            _sut = new IsSimianValidator(_mockSimianRepository.Object);
        }

        [Fact]
        public void Should_Have__Not_Errors()
        {
            string[] dna = new string[] {
                "CTGAGA", "CTATGC", "TATTGT", "AGAGGG", "CCCCTA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            SimianEntity? simianNull = null;

            _mockSimianRepository.Setup(c => c.GetAsync(string.Join(",", data.Dna))).ReturnsAsync(simianNull);

            var result = _sut.Validate(data);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            string[] dna = new string[] { };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            SimianEntity? simianNull = null;

            _mockSimianRepository.Setup(c => c.GetAsync(string.Join(",", data.Dna))).ReturnsAsync(simianNull);

            var result = _sut.Validate(data);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void Should_Have_Error_When_Dna_Exist_In_Base()
        {
            string[] dna = new string[] {
                "CTGAGA", "CTATGC", "TATTGT", "AGAGGG", "CCCCTA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };

            _mockSimianRepository.Setup(c => c.GetAsync(string.Join(",", data.Dna))).ReturnsAsync(new SimianEntity(1, "", false, null, null));

            var result = _sut.Validate(data);
            Assert.NotEmpty(result.Errors);
        }
    }
}
