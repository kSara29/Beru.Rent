using FastEndpoints;

namespace Chat.Dto.RequestDto;

public class CreateChatRequest
{
    public required string User1 { get; init; }
    public required string User2 { get; init; }
}