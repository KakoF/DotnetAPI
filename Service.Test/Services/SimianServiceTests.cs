using Castle.Core.Logging;
using Domain.Abstractions;
using Domain.DTO.IsSimianDTO;
using Domain.Entities;
using Domain.Interfaces.Notifications;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Notifications;
using Microsoft.Extensions.Logging;
using Moq;
using Service.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test.Services
{
    public class SimianServiceTests
    {

        private readonly SimianService _sut;
        private readonly MockRepository _mock;
        private readonly Mock<ILogger<SimianService>> _mockLogger;
        private readonly Mock<ISimianPatternsExecute> _mockPatternsExecute;
        private readonly Mock<ISimianRepository> _mockRepository;
        private readonly Mock<INotificationHandler<Notification>> _mockNotification;



        public SimianServiceTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockLogger = _mock.Create<ILogger<SimianService>>();
            _mockPatternsExecute = _mock.Create<ISimianPatternsExecute>();
            _mockRepository = _mock.Create<ISimianRepository>();
            _mockNotification = _mock.Create<INotificationHandler<Notification>>();
            _sut = new SimianService(_mockLogger.Object, _mockPatternsExecute.Object, _mockRepository.Object, _mockNotification.Object);
        }
    }
}
