using Ad.Application.Contracts.File;
using Ad.Dto.CreateDtos;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace Ad.Api.Controllers;

[ApiController]
public class FileController : ControllerBase
{
    #region Общение в базой Miniom
    private readonly IMinioClient minioClient;
    private readonly IFileService _service;

    public FileController(IMinioClient minioClient, IFileService service)
    {
        this.minioClient = minioClient;
        _service = service;
    }
// тут мы должны получить файл и отправить его на загрузку в минио и постгресс и в ответе получить мессадж с успехом и данными файла

    [HttpPost("/api/file/upload")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFile([FromForm] CreateFileDto fileDto)
    {

        await _service.UploadFileAsync(fileDto);

       
        string bucketID = fileDto.AdId.ToString(); 
        string objectName = fileDto.File.FileName; 

        var presignedUrl = await minioClient.PresignedPutObjectAsync(new PresignedPutObjectArgs()
                .WithBucket(bucketID)
                .WithObject(objectName))
            .ConfigureAwait(false);

        // Return the presigned URL or other response as needed
        return Ok(presignedUrl);
    }

    [HttpPost("api/delete/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteFile([FromRoute] Guid id)
    {
        await _service.RemoveFileAsync(id);
        return Ok("Файл удален");
    }



    [HttpGet("api/file/get/{id}")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFile([FromRoute] Guid id)
    {
        var response = await _service.GetFileAsync(id); // Assuming GetFileAsync returns byte[]
        return Ok(response);

    }



    #endregion
}