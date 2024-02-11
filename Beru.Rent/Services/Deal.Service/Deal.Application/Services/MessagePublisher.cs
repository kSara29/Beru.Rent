using System.Text;
using Deal.Application.Contracts.Deal;
using Deal.Application.Message;
using Newtonsoft.Json;
using RabbitMQ.Client;

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
        ConnectionFactory factory = new();
        factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        factory.ClientProvidedName = "Rabbit sender";
        
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            string exchangeName = "myExchange";
            string routingKey = "myRoutingKey";
            string queueName = "myQueue";
            
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            
            string messageJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            channel.BasicPublish(exchangeName, routingKey, null, body);
            
            Console.WriteLine($" [x] Sent {messageJson}");
        }
    }

}