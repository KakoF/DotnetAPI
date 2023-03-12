using Domain.Abstractions;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Notifications;
using Domain.Models.Clients;
using Domain.Models.Clients.ChuckNorris;
using Domain.Notifications;
using Microsoft.Extensions.Logging;

namespace IntegratorHttpClient.Implementations
{
    public class ChuckNorrisClient : ClientFactoryAbstract<ChuckNorrisModel, ClientResponseModel>, IChuckNorrisClient
    {
        public ChuckNorrisClient(HttpClient httpClient, ILogger<ChuckNorrisClient> logger, INotificationHandler<Notification> notification): base(httpClient, logger, notification) { }
    }
}
