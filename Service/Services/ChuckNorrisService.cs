using Domain.Interfaces.Services;
using Domain.Interfaces.Clients;
using Domain.Models.Clients.ChuckNorris;
using IntegratorMessageQueue.Models;
using IntegratorMessageQueue.Interfaces.RabbitMq;

namespace Service.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly IRabbitMqIntegrator _rabbit;
        private readonly IChuckNorrisClient _client;

        public ChuckNorrisService(IRabbitMqIntegrator rabbit, IChuckNorrisClient client)
        {
            _rabbit = rabbit;
            _client = client;
        }

        public async Task<ChuckNorrisModel> Get()
        {
            var respone = await _client.Get("jokes/random");
            if (respone?.Data != null)
                _rabbit.PublishExchange(respone.Data, queueName: "ChuckNorrisQueue", exchange: "ChuckNorris", routingKey: "inserted", EnumExchangeTypes.direct, durable: true);

            return (ChuckNorrisModel)respone?.Data ?? null;
        }
        
    }
}
