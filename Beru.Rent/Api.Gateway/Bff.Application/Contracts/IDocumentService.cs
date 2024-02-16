using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IDocumentService
{
    Task<ResponseModel<DocDataDto>> GenerateDoc(RequestById dto);
}