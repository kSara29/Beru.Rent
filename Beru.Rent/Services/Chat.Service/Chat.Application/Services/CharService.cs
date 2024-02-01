using Chat.Application.Contracts;
using Chat.Domain.Model;
using Chat.Dto.RequestDto;

namespace Chat.Application.Services;

public class CharService: IChatService
{
    private readonly IChatRepository _chatRepository;

    public CharService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }
    
    public async Task<Domain.Model.Chat> CreateChatAsync(CreateChatRequest newChat)
    {
        var response = await _chatRepository.CreateChatAsync(newChat);
        return response;
    }

    public async Task<Domain.Model.Chat> SaveMessageAsync(Guid chatId, Message message)
    {
        var response = await _chatRepository.SaveMessageAsync(chatId, message);
        return response;
    }

    public async Task<List<Message>> GetMessagesByChatIdAsync(Guid chatId)
    {
        var response = await _chatRepository.GetMessagesByChatIdAsync(chatId);
        return response;
    }
}