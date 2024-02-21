namespace User.Api.JsonOptions;

public class EmailSender
{
    public const string Name = "Email";
    
    public required string Url { get; init; }
    public required string Port { get; init; }
    public required string From { get; init; }
    public required string Password { get; init; }
    
    public int PortAsInt => Convert.ToInt32(Port);
}