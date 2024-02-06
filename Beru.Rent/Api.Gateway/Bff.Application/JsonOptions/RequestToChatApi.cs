namespace Bff.Application.JsonOptions;

public class RequestToChatApi
{
    public const string Name = "ChatServiceUrl";
    
    public required string Url { get; init; }
}