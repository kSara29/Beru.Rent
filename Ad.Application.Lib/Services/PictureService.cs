using Ad.Api.Mapper;
using Ad.Application.Lib.DTO;
using Ad.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Application.Lib.Services;

public class PictureService
{
   private IPictureRepository _repository;

   public PictureService(IPictureRepository repository)
   {
      _repository = repository;
   }
   
   public async Task SavePic([FromBody] PictureDto dto)
   {
      var model = dto.PictureToModel();
      _repository.SavePictureAnync(model);
   }
}