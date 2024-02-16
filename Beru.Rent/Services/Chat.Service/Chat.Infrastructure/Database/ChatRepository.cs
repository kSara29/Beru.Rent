using Chat.Application.Contracts;
using Chat.Domain.Model;
using Chat.Dto.RequestDto;
using Chat.Dto.ResponseModel;
using Common;
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
    
    public async Task<Domain.Model.Chat> CreateChatAsync(CreateChatRequest newChat)
    {
        var chatId = Guid.NewGuid();
        
        var initNewChat = new Domain.Model.Chat()
        {
            CreatedAt = DateTime.UtcNow,
            Participants = new List<string>() { newChat.User1, newChat.User2 },
            Id = chatId,
            Messages = []
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

    public async Task<Domain.Model.Chat?> SaveMessageAsync(Guid chatId, Message message)
    {
        var filter = Builders<Domain.Model.Chat>.Filter.Eq(chat => chat.Id, chatId); 
        var update = Builders<Domain.Model.Chat>.Update.Push(chat => chat.Messages, message); 

        await _chatCollection.UpdateOneAsync(filter, update);
        var response = await _chatCollection.Find(x => x.Id == chatId).FirstOrDefaultAsync();

        return response;

    }

    
    public async  Task<ResponseModel<List<MessageDto>>?> GetMessagesByChatIdAsync(Guid chatId)
    {
        var chat = await _chatCollection.Find(x => x.Id == chatId).FirstOrDefaultAsync();
        var messageHistory = new List<MessageDto>();
        
        foreach (var mes in chat.Messages)
        {
            var mesDto = new MessageDto()
            {
                SenderId = mes.SenderId,
                MessageId = mes.MessageId,
                CreatedAt = mes.CreatedAt,
                Text = mes.Text
            };
            
            messageHistory.Add(mesDto);
        }
        if (messageHistory != null)
        {
            return ResponseModel<List<MessageDto>>.CreateSuccess(messageHistory);
        }
        else
        {
            var errors = new List<ResponseError?> { new ResponseError { Code = "NotFound", Message = "Chat history not found." } };
            return ResponseModel<List<MessageDto>>.CreateFailed(errors);
        }
        
    }

    public async Task<List<string>> GetChatParticipants(Guid chatId)
    {
        var chat = await _chatCollection.Find(x => x.Id == chatId).FirstOrDefaultAsync();

        return chat.Participants;
    }

    public async Task<ResponseModel<List<GetAllChatsResponse>>> GetAllChats(string userId)
    {
        var chats = await _chatCollection.Find(x => x.Participants.Contains(userId)).ToListAsync();
        var chatsList = new List<GetAllChatsResponse>(); 
        
        foreach (var chat in chats)
        {
            var messageHistory = new List<MessageDto>();
            foreach (var mes in chat.Messages)
            {
                var mesDto = new MessageDto()
                {
                    SenderId = mes.SenderId,
                    MessageId = mes.MessageId,
                    CreatedAt = mes.CreatedAt,
                    Text = mes.Text
                };
            
                messageHistory.Add(mesDto);
            }
            
            var chatDto = new GetAllChatsResponse()
            {
                Id = chat.Id,
                Participants = chat.Participants,
                CreatedAt = chat.CreatedAt,
                Messages = messageHistory
            };
            
            chatsList.Add(chatDto);
        }

        return ResponseModel<List<GetAllChatsResponse>>.CreateSuccess(chatsList);
    }
}