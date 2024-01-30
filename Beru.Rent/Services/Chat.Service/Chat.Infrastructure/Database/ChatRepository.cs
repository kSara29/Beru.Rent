using Chat.Application.Contracts;
using MongoDB.Driver;

namespace Chat.Infrastructure.Database;

public class ChatRepository: IChatRepository
{
    private readonly IMongoCollection<Domain.Model.Chat> _chatCollection;
    
    public ChatRepository(IChatDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _chatCollection = database.GetCollection<Domain.Model.Chat>(settings.ChatCollectionName);
    }
    
    
    public async Task<Domain.Model.Chat> CreateChatAsync(Guid user1, Guid user2)
    {
        var chatId = Guid.NewGuid();
        
        var initNewChat = new Domain.Model.Chat()
        {
            CreatedAt = DateTime.UtcNow,
            Participants = new List<Guid>() { user1, user2 },
            Id = chatId
        };
        try
        {
            await _chatCollection.InsertOneAsync(initNewChat);
            var response = await _chatCollection.Find(x => x.Id == chatId).FirstOrDefaultAsync();
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вставке: {ex.Message}");
            return null;
        }
    }
}