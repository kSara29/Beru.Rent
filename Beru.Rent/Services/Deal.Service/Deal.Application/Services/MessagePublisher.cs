using System.Text;
using Deal.Application.Contracts.Deal;
using Deal.Application.Message;
using Newtonsoft.Json;

namespace Deal.Application.Services;

public class MessagePublisher: IMessagePublisher
{
    private readonly string _hostname;
    
    
    public MessagePublisher(string hostname)
    {
        _hostname = hostname;
    }

    public void PublishDealCreatedMessage(ChatCreatedMessage message)
    {
        var factory = new ConnectionFactory() { HostName = _hostname };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "chatCreationQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            string messageJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            channel.BasicPublish(exchange: "",
                routingKey: "chatCreationQueue",
                basicProperties: null,
                body: body);
        }
    }
}