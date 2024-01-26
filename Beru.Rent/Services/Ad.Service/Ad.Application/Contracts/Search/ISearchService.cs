using Ad.Domain.Models;

namespace Ad.Application.Contracts.Search;

public interface ISearchService
{
    Task<List<Advertisement>> SearchByTitle(string search);
}