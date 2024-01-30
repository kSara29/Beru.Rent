using Chat.Application.Contracts;

namespace Chat.Application.Services;

public class CharService: IChatService
{
    private readonly IChatRepository _chatRepository;

    public CharService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }
    
    public async Task<Domain.Model.Chat> CreateChatAsync(Guid user1, Guid user2)
    {
        var responce = await _chatRepository.CreateChatAsync(user1, user2);
        return responce;
    }
}