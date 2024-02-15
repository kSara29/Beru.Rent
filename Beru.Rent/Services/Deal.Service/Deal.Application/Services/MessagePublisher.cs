using System.Text;
using Deal.Application.Contracts.Deal;
using Deal.Application.Message;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Deal.Application.Services;

public class MessagePublisher : IMessagePublisher
{
    private readonly string _hostname;
    private IConnection _connection;
    private IModel _channel;
    private const string ResponseQueueName = "responseQueue";
    
    public MessagePublisher(string hostname)
    {
        _hostname = hostname;
        InitializeRabbitMq();
    }

    private void InitializeRabbitMq()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri(_hostname),
            ClientProvidedName = "Rabbit sender"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(ResponseQueueName, false, false, false, null);
    }

    public Task<Guid> PublishDealCreatedMessageAsync(ChatCreatedMessage message)
    {
        var completionSource = new TaskCompletionSource<Guid>();
        var correlationId = Guid.NewGuid().ToString();
        var responseQueue = _channel.QueueDeclare().QueueName;

        var properties = _channel.CreateBasicProperties();
        properties.CorrelationId = correlationId;
        properties.ReplyTo = responseQueue;

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            if (ea.BasicProperties.CorrelationId == correlationId)
            {
                var response = Encoding.UTF8.GetString(ea.Body.ToArray()).Trim('"');
        
                if(Guid.TryParse(response, out Guid chatId)) completionSource.TrySetResult(chatId); 
                else completionSource.TrySetException(new InvalidOperationException("Invalid GUID received."));
            }
            else Console.WriteLine($"CorrelationId does not match. Expected: {correlationId}, Received: {ea.BasicProperties.CorrelationId}");
        };

        _channel.BasicConsume(consumer: consumer, queue: responseQueue, autoAck: true);

        string messageJson = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(messageJson);

        _channel.BasicPublish(
            exchange: "",
            routingKey: "myQueue",
            basicProperties: properties,
            body: body
        );
        
        return completionSource.Task;
    }

    public void Dispose()
    {
        _channel?.Close();
        _channel?.Dispose();
        _connection?.Close();
        _connection?.Dispose();
    }
}