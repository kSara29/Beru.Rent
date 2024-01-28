namespace Bff.Application.JsonOptions;

public class RequestToUserApi
{
    public const string Name = "UserServiceUrl";
    
    public required string Url { get; init; }
}