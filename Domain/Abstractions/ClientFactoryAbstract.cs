using Domain.Interfaces.Notifications;
using Domain.Interfaces.Services;
using Domain.Models.Clients;
using Domain.Notifications;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Domain.Abstractions
{
    public abstract class ClientFactoryAbstract<T, O> : IClientFactory<T, ClientResponseModel>
    {
        protected readonly ILogger<ClientFactoryAbstract<T, O>> _logger;
        protected readonly HttpClient _httpClient;
        private readonly INotificationHandler<Notification> _notification;
        public ClientFactoryAbstract(HttpClient httpClient, ILogger<ClientFactoryAbstract<T, O>> logger, INotificationHandler<Notification> notification)
        {
            _httpClient = httpClient;
            _logger = logger;
            _notification = notification;
        }
        public virtual async Task<ClientResponseModel> Get(string path)
        {
            var clientResponse = await _httpClient.GetAsync(path);
            if(clientResponse.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
                return new ClientResponseModel((int)clientResponse.StatusCode, response);
            }
            var error = await clientResponse.Content.ReadAsStringAsync();
            _notification.AddNotification((int)clientResponse.StatusCode, "Erro em consumir recurso", $"Erro {_httpClient.BaseAddress}/{path}");
            //_notification.AddNotification((int)clientResponse.StatusCode, error, error);
            return null;
        }

        public virtual async Task<ClientResponseModel> Post(string path, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), UnicodeEncoding.UTF8, "application/json");
            var clientResponse = await _httpClient.PostAsync(path, content);
            if (clientResponse.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
                return new ClientResponseModel((int)clientResponse.StatusCode, response);
            }
            var error = await clientResponse.Content.ReadAsStringAsync();
            _notification.AddNotification((int)clientResponse.StatusCode, "Erro em consumir recurso", $"Erro {_httpClient.BaseAddress}/{path}");
            //_notification.AddNotification((int)clientResponse.StatusCode, error, error);
            return null;
        }

       
    }
}
