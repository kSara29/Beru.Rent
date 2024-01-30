using Ad.Domain.Models;
using Ad.Dto.GetDtos;
using Common;

namespace Ad.Application.Contracts.Search;

public interface ISearchService
{
    Task<ResponseModel<List<AdDto>>> SearchByTitle(string search);
}