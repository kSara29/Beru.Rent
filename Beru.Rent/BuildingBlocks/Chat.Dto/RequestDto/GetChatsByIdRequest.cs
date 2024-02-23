using FastEndpoints;

namespace Chat.Dto.RequestDto;

public class GetChatsByIdRequest
{
    [QueryParam] public string? Id { get; set; }
}