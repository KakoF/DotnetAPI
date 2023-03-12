using IntegratorMessageQueue.Models;

namespace IntegratorMessageQueue.Interfaces.RabbitMq
{
    public interface IRabbitMqIntegrator
    {
        public void ConfigureQueue(string queueName, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null);
        public void PublishQueue<T>(T messageBody, string queueName, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null);
        public void PublishExchange<T>(T messageBody, string queueName, string exchange, string routingKey, EnumExchangeTypes type, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null);
       
    }
}
