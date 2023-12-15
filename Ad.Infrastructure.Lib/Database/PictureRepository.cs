using Ad.Application.Lib.Services;
using Ad.Domain.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel.Result;
using Minio.Exceptions;

namespace Ad.Infrastructure.Lib.Database;

public class PictureRepository : IPictureRepository
{
    private PictureDbContext _context;

    public PictureRepository(PictureDbContext context)
    {
        _context = context;
    }
    
    public async Task<HttpResponseMessage> SavePictureAnync(PictureInGallery pictureInGallery)
    {
        await _context.Pictures.AddAsync(pictureInGallery);
        await _context.SaveChangesAsync();

        return new HttpResponseMessage();
        
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