using Ad.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Ad.Application.Contracts.File;

public interface IFileRepository
{
    Task<Guid> UploadFileAsync(FileModel entity, IFormFile file);
    Task<string> RemoveFileAsync(Guid id);
    Task<byte[]?> GetFileAsync(Guid id);
    Task<List<byte[]?>> GetAllFilesAsync(Guid bucketId);
}