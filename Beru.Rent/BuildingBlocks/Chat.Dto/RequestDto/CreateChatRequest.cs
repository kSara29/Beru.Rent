using FastEndpoints;

namespace Chat.Dto.RequestDto;

public class CreateChatRequest
{
    public required Guid User1 { get; init; }
    public required Guid User2 { get; init; }
}