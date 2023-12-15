using Ad.Api.DTO;
using Ad.Api.Mapper;
using Ad.Application.Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PictureDto = Ad.Application.Lib.DTO.PictureDto;


[ApiController]
[Route("api/[controller]")]

public class PictureController : ControllerBase
{
    private readonly IMinioClient minioClient;
    private IPictureService _pictureService;
    private IPictureRepository _repository;

    public PictureController(IMinioClient minioClient, IPictureService pictureService, IPictureRepository repository)
    {
        this.minioClient = minioClient;
        _pictureService = pictureService;
        _repository = repository;
    }
    
    [HttpPost]
    public async Task<ActionResult> SavePicture([FromBody] PictureDto dto)
    {
        var model = dto.PictureToModel();
         _pictureService.SavePictureAnync(model);
        return Ok();
    }


}
