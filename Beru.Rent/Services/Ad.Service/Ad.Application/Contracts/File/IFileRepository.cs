using Ad.Domain.Models;

namespace Ad.Application.Contracts.File;

public interface IFileRepository
{
    Task<Guid> UploadFileAsync(FileModel entity, IFormFile file);
    Task<string> RemoveFileAsync(Guid id);
    Task<byte[]> GetFileAsync(Guid id);
}