namespace Ad.Application.Lib.Contracts.Tag;

public interface ITagService
{
    Task<bool> CreateTagAsync(Domain.Core.Models.Tag tag);
}