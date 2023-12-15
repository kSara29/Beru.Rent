using System.Text.Json.Serialization;

namespace Ad.Api.DTO;

public class PictureDto
{
    [property: JsonPropertyName("userId")]
    public string UserId { get; set; }
    [property: JsonPropertyName("pictureFile")]

    public IFormFile PictureFile { get; set; }
    [property: JsonPropertyName("adId")]
    public Guid AdId { get; set; }
}