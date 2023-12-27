
public interface ITagRepository
{
    Task<bool> CreateTagAsync(Tag tag);
    Task<bool> DeleteTagAsync(Tag tag);
    Task<Tag> GetTagById(string id);
}