using Infrastructure.Entity;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.RabbitMQ.SotrudnikMQ
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "sotrudnik_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public Task PublishAddSotrudnikAsync(Sotrudnik sotrudnik)
        {
            var message = JsonConvert.SerializeObject(new { Action = "Add", Data = sotrudnik });
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "sotrudnik_queue", basicProperties: null, body: body);
            return Task.CompletedTask;
        }

        public Task PublishUpdateSotrudnikAsync(Sotrudnik sotrudnik)
        {
            var message = JsonConvert.SerializeObject(new { Action = "Update", Data = sotrudnik });
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "sotrudnik_queue", basicProperties: null, body: body);
            return Task.CompletedTask;
        }

        public Task PublishDeleteSotrudnikAsync(int id)
        {
            var message = JsonConvert.SerializeObject(new { Action = "Delete", Data = id });
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "sotrudnik_queue", basicProperties: null, body: body);
            return Task.CompletedTask;
        }
    }
}
