using Chat.Dto.ResponseModel;
using Common;

namespace Chat.Application.Contracts;

public interface IChatRepository
{
    Task<ResponseModel<ChatDto>> GetChatAsync(Guid id);
}