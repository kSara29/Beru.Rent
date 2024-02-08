namespace Ad.Application.JsonOptions;

public class MinioOptions
{
    public const string Name = "Minio";
    public required string Endpoint { get; set; }
    public required string AccessKey { get; set; }
    public required string SecretKey { get; set; }
}