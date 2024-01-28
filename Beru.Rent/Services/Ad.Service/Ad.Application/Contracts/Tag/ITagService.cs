using Ad.Application.Responses;
using Ad.Dto.CreateDtos;

namespace Ad.Application.Contracts.Tag;

public interface ITagService
{
    Task<BaseApiResponse<Guid>> CreateTagAsync(TagDto tag);
}