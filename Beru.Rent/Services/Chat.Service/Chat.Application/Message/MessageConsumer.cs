using System.Text;
using Chat.Application.Contracts;
using Chat.Dto.RequestDto;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Chat.Application.Message;

public class MessageConsumer
{
    private readonly IChatService _chatService; 
    private IConnection _connection;
    private IModel _channel;

    public MessageConsumer(IChatService chatService)
    {
        _chatService = chatService;
        InitializeRabbitMQ();
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672"),
            ClientProvidedName = "Rabbit receiver"
        };
        
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        
        string exchangeName = "myExchange";
        string routingKey = "myRoutingKey";
        string queueName = "myQueue";
        
        _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
        _channel.QueueDeclare(queueName, false, false, false, null);
        _channel.QueueBind(queueName, exchangeName, routingKey, null);
        _channel.BasicQos(0, 1, false);
    }

    public void StartConsuming()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var messageString = Encoding.UTF8.GetString(body);
            var chatCreatedMessage = JsonConvert.DeserializeObject<ChatCreatedMessage>(messageString);
            
            Console.WriteLine($"Message received: {messageString}");
            
            var createChatRequest = new CreateChatRequest
            {
                User1 = chatCreatedMessage.Users[0],
                User2 = chatCreatedMessage.Users[1]
            };

            try
            {
                await _chatService.CreateChatAsync(createChatRequest);
                Console.WriteLine($"Chat created for deal ID: {chatCreatedMessage.DealId}");
                _channel.BasicAck(ea.DeliveryTag, false);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error creating chat: {ex.Message}");
            }
        };

        _channel.BasicConsume("myQueue", false, consumer);
    }

    public void Dispose()
    {
        if (_channel.IsOpen)
        {
            _channel.Close();
            _channel.Dispose();
        }
        if (_connection.IsOpen)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}