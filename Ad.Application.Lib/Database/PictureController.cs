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

}
