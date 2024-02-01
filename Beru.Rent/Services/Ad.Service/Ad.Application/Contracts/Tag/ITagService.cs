using Ad.Application.Responses;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Contracts.Tag;

public interface ITagService
{
    Task<ResponseModel<GuidResponse>> CreateTagAsync(TagDto tag);
}