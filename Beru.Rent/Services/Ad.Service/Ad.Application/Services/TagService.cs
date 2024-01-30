using Ad.Api.Mapper;
using Ad.Application.Contracts.Tag;
using Ad.Application.Responses;
using Ad.Domain.Models;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Services;

public class TagService: ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public async Task<ResponseModel<GuidResponse>> CreateTagAsync(TagDto tag)
    {
       var result = await _tagRepository.CreateTagAsync(tag.ToDomain());
       return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse
       {
           Id = result
       });
    }
}