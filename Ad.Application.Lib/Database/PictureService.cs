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
   
   public async Task SavePic([FromBody] PictureInGallery dto)
   {
      _repository.SavePictureAnync();
   }
}