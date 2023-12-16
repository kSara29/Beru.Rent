using Ad.Domain.Core.Models;
using Minio.DataModel.Result;

namespace Ad.Application.Lib.Services;

public interface IPictureService
{
    public bool SavePictureAnync(PictureInGallery pictureInGallery);
    public Task<ResponseResult> DeletePictureAnync(Guid id);
    public PictureInGallery GetPictureAsync(Guid id);
}