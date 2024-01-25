namespace Bff.Application.JsonOptions;

public class RequestToUserApi
{
    public const string Name = "HttpsRequestStringToUserApi";
    
    public required string GetUserById { get; init; }
    public required string GetUserByEmail { get; init; }
    public required string GetUserByName { get; init; }
    public required string DeleteUser { get; init; }
    public required string UpdateUser { get; init; }
    public required string CreateUser { get; init; }
    public required string Auth { get; init; }
}