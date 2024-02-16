namespace Chat.Dto.ResponseModel;

public class GetAllChatsResponse
{
    public Guid Id { get; set; }
    public List<string> Participants { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; }
    public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
}