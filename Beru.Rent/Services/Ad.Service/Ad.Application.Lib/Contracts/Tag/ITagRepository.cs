namespace Ad.Application.Lib.Contracts.Tag;

public interface ITagRepository
{
    Task<bool> CreateTagAsync(Domain.Core.Models.Tag tag);
    Task<bool> DeleteTagAsync(Domain.Core.Models.Tag tag);
    Task<Domain.Core.Models.Tag> GetTagById(string id);
}