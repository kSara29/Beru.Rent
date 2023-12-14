namespace Ad.Application.Lib.Services;

public class PictureService
{
   private IPictureRepository _repository;

   public PictureService(IPictureRepository repository)
   {
      _repository = repository;
   }

   public async Task SavePic()
   {
      _repository.SavePictureAnync();
   }
}