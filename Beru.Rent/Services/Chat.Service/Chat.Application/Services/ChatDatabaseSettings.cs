using Chat.Application.Contracts;

namespace Chat.Application.Services;

public class ChatDatabaseSettings: IChatDatabaseSettings
{
    public string ChatCollectionName { get; set; } = String.Empty;
    public string DefaultConnection { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}