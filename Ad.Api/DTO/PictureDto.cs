namespace Ad.Api.DTO;

public class PictureDto
{
    public string UserId { get; set; }
    public byte[] PictureBytes { get; set; }
    public Guid AdId { get; set; }
}