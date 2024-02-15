using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;

namespace Bff.Application.Contracts;

public interface IChatService
{
    Task<ResponseModel<ChatDtoResponse>> CreateChatAsync(CreateChatRequest request);
    Task<ResponseModel<SendMessageResponse>> SendMessageAsync(SendMessageRequest request);
    Task<ResponseModel<List<MessageDto>>> LoadChatHistoryAsync(RequestById request, string UserId);
}