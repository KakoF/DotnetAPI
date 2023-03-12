using Domain.Abstractions;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Notifications;
using Domain.Models.Clients;
using Domain.Models.Clients.Advice;
using Domain.Notifications;
using Microsoft.Extensions.Logging;

namespace IntegratorHttpClient.Implementations
{
    public class AdviceClient : ClientFactoryAbstract<AdviceModel, ClientResponseModel>, IAdviceClient
    {
        public AdviceClient(HttpClient httpClient, ILogger<AdviceClient> logger, INotificationHandler<Notification> notification) : base(httpClient, logger, notification) { }
    }
}
