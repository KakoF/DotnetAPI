using IntegratorMessageQueue.Interfaces.RabbitMq;
using IntegratorMessageQueue.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace IntegratorMessageQueue.RabbitMq
{
    public class RabbitMqIntegrator : IRabbitMqIntegrator
    {
        private readonly ILogger<RabbitMqIntegrator> _logger;
        private readonly IModel _channel;

        public RabbitMqIntegrator(ILogger<RabbitMqIntegrator> logger, string connectionStringRabbit)
        {
            _logger = logger;
            var _connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(connectionStringRabbit)
            };
            var _model = _connectionFactory.CreateConnection();
            _channel = _model.CreateModel();
        }

       
        public void ConfigureQueue(string queueName, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            _channel.QueueDeclare(queue: queueName, durable: durable, exclusive: exclusive, autoDelete: autoDelete, arguments: arguments);

        }
      
        public void PublishQueue<T>(T messageBody, string queueName, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            var stringMessage = JsonConvert.SerializeObject(messageBody);
            try
            {
                _channel.QueueDeclare(queue: queueName, durable: durable, exclusive: exclusive, autoDelete: autoDelete, arguments: arguments);
               
                var byteMessage = Encoding.UTF8.GetBytes(stringMessage);
                _channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: null, body: byteMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro em publicar a mensagem para fila: {queueName} mesagem: {stringMessage}");
            }

        }

        public void PublishExchange<T>(T messageBody, string queueName, string exchange, string routingKey, EnumExchangeTypes type, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            var stringMessage = JsonConvert.SerializeObject(messageBody);
            try
            {
                _channel.QueueDeclare(queue: queueName, durable: durable, exclusive: exclusive, autoDelete: autoDelete, arguments: arguments);
                _channel.ExchangeDeclare(exchange: exchange, type.ToString(), durable: durable, autoDelete: autoDelete, arguments: arguments);
                _channel.QueueBind(queueName, exchange, routingKey, arguments);

                var byteMessage = Encoding.UTF8.GetBytes(stringMessage);
                _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: byteMessage);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Erro em publicar a mensagem para exchange: {exchange} fila: {queueName} routingKey: {routingKey} mesagem: {stringMessage}");
            }
        }
    }
}