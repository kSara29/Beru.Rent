namespace Chat.Dto.ResponseModel;

public class ChatDtoResponse
{
    public Guid Id { get; set; }
    public List<string> Participants { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; }
    
}