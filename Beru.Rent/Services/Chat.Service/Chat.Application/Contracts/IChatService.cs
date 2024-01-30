using Chat.Dto.ResponseModel;
using Common;

namespace Chat.Application.Contracts;

public interface IChatService
{
    Task<ResponseModel<Guid>> CreateChatAsync(ChatDto ad);
}