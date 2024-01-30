namespace Chat.Application.Contracts;

public interface IChatService
{
    public Task<Domain.Model.Chat> CreateChatAsync(Guid User1, Guid User2);
}