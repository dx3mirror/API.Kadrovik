using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Infrastructure.RabbitMQ;


public class SotrudnikQueueListener : BackgroundService
{
    private readonly ILogger<SotrudnikQueueListener> _logger;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public SotrudnikQueueListener(ILogger<SotrudnikQueueListener> logger)
    {
        _logger = logger;
        var factory = new ConnectionFactory() { HostName = "localhost" }; 
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "sotrudnik_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation($"Received message: {message}");

            // Обработка команды
            try
            {
                var command = JsonConvert.DeserializeObject<Command>(message);
                await ProcessCommandAsync(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message");
            }
        };

        _channel.BasicConsume(queue: "sotrudnik_queue", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }

    private async Task ProcessCommandAsync(Command command)
    {
        switch (command.Action)
        {
            case "Add":
                await AddSotrudnikAsync(command.Data);
                break;
            case "Update":
                await UpdateSotrudnikAsync(command.Data);
                break;
            case "Delete":
                await DeleteSotrudnikAsync(command.Data);
                break;
            default:
                _logger.LogWarning($"Unknown action: {command.Action}");
                break;
        }
    }

    private Task AddSotrudnikAsync(object data)
    {
        _logger.LogInformation($"Adding sotrudnik: {data}");
        return Task.CompletedTask;
    }

    private Task UpdateSotrudnikAsync(object data)
    {
        _logger.LogInformation($"Updating sotrudnik: {data}");
        return Task.CompletedTask;
    }

    private Task DeleteSotrudnikAsync(object data)
    {
        _logger.LogInformation($"Deleting sotrudnik with ID: {data}");
        return Task.CompletedTask;
    }
}
