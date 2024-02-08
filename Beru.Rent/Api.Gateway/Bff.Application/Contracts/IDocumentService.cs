using Common;

namespace Bff.Application.Contracts;

public interface IDocumentService
{
    Task<ResponseModel<byte[]>> GenerateDoc(RequestById dto);
}