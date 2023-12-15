using Ad.Application.Lib.Contracts.Tag;
using Ad.Domain.Core.Models;

namespace Ad.Application.Lib.Services;

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
}