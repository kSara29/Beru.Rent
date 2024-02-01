using Chat.Domain.Model;

namespace Chat.Application.Contracts;

public interface IChatService
{
    public Task<Domain.Model.Chat> CreateChatAsync(Guid User1, Guid User2);
    public Task<Domain.Model.Chat> SaveMessageAsync(Guid ChatId, Message message);
    public Task<List<Message>> GetMessagesByChatIdAsync(Guid chatId);
}