using Domain.Interfaces.Services;
using Domain.Models.Clients.Advice;
using Domain.Interfaces.Clients;
using IntegratorMessageQueue.Interfaces.RabbitMq;
using IntegratorMessageQueue.Models;

namespace Service.Services
{
    public class AdviceService : IAdviceService
    {
        private readonly IRabbitMqIntegrator _rabbit;
        private readonly IAdviceClient _client;

        public AdviceService(IRabbitMqIntegrator rabbit, IAdviceClient client)
        {
            _rabbit = rabbit;
            _client = client;
        }

        public async Task<AdviceModel> Get()
        {
            var respone = await _client.Get("advice");
            if (respone?.Data != null)
                _rabbit.PublishExchange(respone.Data, queueName: "AdviceQueue", exchange: "Advice", routingKey: "inserted", EnumExchangeTypes.direct, durable: true);
            return (AdviceModel)respone?.Data ?? null;
        }

    }
}
