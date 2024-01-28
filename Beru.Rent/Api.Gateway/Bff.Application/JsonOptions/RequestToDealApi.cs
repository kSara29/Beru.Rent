namespace Bff.Application.JsonOptions;

public class RequestToDealApi
{
    public const string Name = "HttpRequestStringToDealApi";
    
    public required string CreateBooking { get; init; }
    public required string GetAllBookings { get; init; }
}