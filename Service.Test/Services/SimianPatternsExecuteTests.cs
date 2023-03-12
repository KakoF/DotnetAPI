using Domain.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using Service.Implementations;
using Service.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Service.Test.Services
{
    public class SimianPatternsExecuteTests
    {
        private readonly SimianPatternsExecute _sut;
        private readonly MockRepository _mock;
        private readonly Mock<IEnumerable<SimianPatternAbstract>> _mockPatterns;



        public SimianPatternsExecuteTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockPatterns = _mock.Create<IEnumerable<SimianPatternAbstract>>();
            _sut = new SimianPatternsExecute(_mockPatterns.Object);
        }
        
    }
}
