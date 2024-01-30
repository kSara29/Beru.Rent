namespace Chat.Application.Contracts;

public interface IChatRepository
{
    public Task<Domain.Model.Chat> CreateChatAsync(Guid User1, Guid User2);
}