namespace Ad.Domain.Models;

public class FileModel:Entity
{
    public string OriginFileName { get; set; }
    public string MinioFileName { get; set; }
    public string AdId { get; set; }
    public string BucketName { get; set; }
}