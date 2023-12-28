using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class FileModel:Entity
{
    public required string OriginFileName { get; set; }
    public string? MinioFileName { get; set; }
    public required Guid AdId { get; set; }
    public Advertisement? Ad { get; set; }
    public string? BucketName { get; set; }
}