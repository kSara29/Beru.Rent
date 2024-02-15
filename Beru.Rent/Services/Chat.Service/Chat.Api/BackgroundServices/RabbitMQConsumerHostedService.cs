using Chat.Application.Message;

namespace Chat.Api.BackgroundServices;

public class RabbitMQConsumerHostedService : IHostedService
{
    private readonly MessageConsumer _messageConsumer;

    public RabbitMQConsumerHostedService(MessageConsumer messageConsumer)
    {
        _messageConsumer = messageConsumer;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(() => _messageConsumer.StartConsuming(), cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}