
using Ad.Domain.Models;

public interface ITagRepository
{
    Task<Guid> CreateTagAsync(Tag tag);
    Task<bool> DeleteTagAsync(Tag tag);
    Task<Tag> GetTagById(string id);
}