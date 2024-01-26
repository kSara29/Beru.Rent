using Ad.Application.Contracts.Tag;
using Ad.Application.Responses;
using Ad.Domain.Models;
using Ad.Dto.CreateDtos;

namespace Ad.Application.Services;

public class TagService: ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public Task<bool> CreateTagAsync(Tag tag)
    {
        return (_tagRepository.CreateTagAsync(tag)); 
    }


    public Task<BaseApiResponse<Guid>> CreateTagAsync(TagDto tag)
    {
        throw new NotImplementedException();
    }
}