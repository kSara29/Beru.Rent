using Ad.Api.DTO;
using Ad.Application.Responses;

namespace Ad.Application.Contracts.Tag;

public interface ITagService
{
    Task<BaseApiResponse<Guid>> CreateTagAsync(TagDto tag);
}