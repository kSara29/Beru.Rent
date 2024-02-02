namespace Chat.Application.Contracts;


public interface IChatDatabaseSettings
{
    string ChatCollectionName { get; set; } 
    string DefaultConnection { get; set; }
    string DatabaseName { get; set; }
}