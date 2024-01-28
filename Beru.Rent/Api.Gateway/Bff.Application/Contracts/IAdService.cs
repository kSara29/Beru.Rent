using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface IAdService
{
    #region методы объявления

    Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad);
    Task<ResponseModel<AdDto>> GetAdAsync(RequestById id);
    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<decimal> GetCostAsync(RequestById adId, DateTime ebeg, DateTime dend);
    Task<StringResponse> GetOwnerIdAsync(RequestById adId);

    #endregion
    
    #region Методы адресов

    Task<ResponseModel<GuidResponse>> CreateAddressAsync(CreateAddressExtraDto dto);
    Task<ResponseModel<StringResponse>> RemoveAddressAsync(RequestById id);
    Task<ResponseModel<AddressExtraDto?>> GetAddressAsync(RequestById id);

    #endregion

    #region Методы категорий
    Task<ResponseModel<GuidResponse>> CreateCategoryAsync(CreateCategoryDto dto);
    Task<ResponseModel<CategoryDto?>> GetCategoryAsync(RequestById id);
    Task<ResponseModel<List<CategoryDto?>>> GetAllCategoriesAsync();
    
    #endregion

    #region Методы работы с файлами

    Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto);
    Task<ResponseModel<StringResponse>> RemoveFileAsync(RequestById id);
    Task<ResponseModel<byte[]>> GetFileAsync(RequestById id);

    #endregion

    #region Методы поиска
    Task<ResponseModel<StringResponse>> SearchByTitle(string search);
    #endregion

    #region Методы Тэгов
    Task<ResponseModel<GuidResponse>> CreateTagAsync(TagDto tag);
    
    #endregion

    #region Методы Тарифов

    Task<ResponseModel<GuidResponse>> CreateTarifAsync(CreateTarifDto dto);
    Task<ResponseModel<bool>> DeleteTarifAsync(RequestById id);

    #endregion

    #region Методы Тайм Юнитов
    Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto);
    Task<ResponseModel<TimeUnitDto?>> GetAsync(RequestById id);
    Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync();

    #endregion
}