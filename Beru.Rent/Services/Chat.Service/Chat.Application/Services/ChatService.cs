using Chat.Application.Contracts;
using Chat.Dto.ResponseModel;
using Common;

namespace Chat.Application.Services;

public class ChatService: IChatService
{
    public Task<ResponseModel<Guid>> CreateChatAsync(ChatDto ad)
    {
        throw new NotImplementedException();
    }
}