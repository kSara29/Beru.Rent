namespace Ad.Application.Lib.Services;

public interface IPictureRepository
{
    public bool SavePictureAnync();
    public bool DeletePictureAnync(Guid id);
    public string GetPictureAsync(Guid id);
}