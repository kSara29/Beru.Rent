using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface ISearchService
{
    Task<ResponseModel<StringResponse>> SearchByTitle(string search);

}