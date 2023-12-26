using Microsoft.AspNetCore.Http;

namespace Ad.Application.Lib.DTO;

public class PictureDto
{
    public string UserId { get; set; }
    public IFormFile PictureFile { get; set; }
    public Guid AdId { get; set; }
}