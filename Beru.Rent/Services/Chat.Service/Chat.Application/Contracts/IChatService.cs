using Chat.Domain.Model;
using Chat.Dto.RequestDto;

namespace Chat.Application.Contracts;

public interface IChatService
{
    public Task<Domain.Model.Chat> CreateChatAsync(CreateChatRequest newChat);
    public Task<Domain.Model.Chat> SaveMessageAsync(Guid ChatId, Message message);
    public Task<List<Message>> GetMessagesByChatIdAsync(Guid chatId);
}