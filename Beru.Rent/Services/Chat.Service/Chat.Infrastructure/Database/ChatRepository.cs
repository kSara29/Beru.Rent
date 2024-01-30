using Chat.Application.Contracts;
using Chat.Dto.ResponseModel;
using Common;

namespace Chat.Infrastructure.Database;

public class ChatRepository: IChatRepository
{
    public Task<ResponseModel<ChatDto>> GetChatAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}