using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class PictureInGallery: Entity
{
    public string UserId { get; set; }
    public byte[] PictureBytes { get; set; }
    public Guid AdId { get; set; }
}