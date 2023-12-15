using Ad.Api.Mapper;
using Ad.Application.Lib.DTO;
using Ad.Domain.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.Result;
using Minio.DataModel.Select;

namespace Ad.Application.Lib.Services;

public class PictureService :IPictureService
{
   private IPictureRepository _repository;

   public PictureService(IPictureRepository repository)
   {
      _repository = repository;
   }

   public bool SavePictureAnync(PictureInGallery pictureInGallery)
   {
      _repository.SavePictureAnync(pictureInGallery);
      return true;
   }

   public Task<ResponseResult> DeletePictureAnync(Guid id)
   {
      throw new NotImplementedException();
   }

   public PictureInGallery GetPictureAsync(Guid id)
   {
      throw new NotImplementedException();
   }
}