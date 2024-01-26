using Ad.Domain.Models;

namespace Ad.Application.Contracts.Search;

public interface ISearchRepository
{
    Task<List<Advertisement>> SearchByTitle(string search);
}