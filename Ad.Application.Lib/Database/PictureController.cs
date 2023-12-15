using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace Ad.Application.Lib.Services;


[ApiController]
public class PictureController : ControllerBase
{
    private readonly IMinioClient minioClient;

    public PictureController(IMinioClient minioClient)
    {
        this.minioClient = minioClient;
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUrl(string bucketID)
    {
        return Ok(await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithBucket(bucketID)
            .ConfigureAwait(false));
    }
}

public class ApiControllerAttribute : Attribute
{
}

[ApiController]
public class ExampleFactoryController : ControllerBase
{
    private readonly IMinioClientFactory minioClientFactory;

    public ExampleFactoryController(IMinioClientFactory minioClientFactory)
    {
        this.minioClientFactory = minioClientFactory;
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUrl(string bucketID)
    {
        var minioClient = minioClientFactory.CreateClient(); //Has optional argument to configure specifics

        return Ok(await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithBucket(bucketID)
            .ConfigureAwait(false));
    }
}
