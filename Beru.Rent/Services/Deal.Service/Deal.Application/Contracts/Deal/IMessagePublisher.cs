using Deal.Application.Message;

namespace Deal.Application.Contracts.Deal;

public interface IMessagePublisher
{
    void PublishDealCreatedMessage(ChatCreatedMessage message);
}