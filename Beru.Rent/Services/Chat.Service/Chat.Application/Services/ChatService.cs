using Chat.Application.Contracts;
using Chat.Domain.Model;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;

namespace Chat.Application.Services;

public class ChatService: IChatService
{
    private readonly IChatRepository _chatRepository;

    public ChatService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }
    
    public async Task<Domain.Model.Chat> CreateChatAsync(CreateChatRequest newChat)
    {
        var response = await _chatRepository.CreateChatAsync(newChat);
        return response;
    }

    public async Task<Domain.Model.Chat?> SaveMessageAsync(Guid chatId, Domain.Model.Message message)
    {
        var response = await _chatRepository.SaveMessageAsync(chatId, message);
        return response;
    }

    public async Task<ResponseModel<List<MessageDto>>?> GetMessagesByChatIdAsync(Guid chatId)
    {
        var response = await _chatRepository.GetMessagesByChatIdAsync(chatId);
        return response;
    }

    public async Task<List<string>> GetChatParticipants(Guid chatId)
    {
        return await _chatRepository.GetChatParticipants(chatId);
    }
}