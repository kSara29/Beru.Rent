using Common;

namespace Bff.Application.Contracts;

public interface IAdService
{
    #region методы объявления

    Task<ResponseModel<Guid>> CreateAdAsync(CreateAdDto ad);
    Task<ResponseModel<AdDto>> GetAdAsync(Guid id);
    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<decimal> GetCostAsync(Guid adId, DateTime ebeg, DateTime dend);
    Task<string> GetOwnerIdAsync(Guid adId);

    #endregion
    
    #region Методы адресов

    Task<ResponseModel<Guid>> CreateAddressAsync(T dto);
    Task<ResponseModel<string>> RemoveAddressAsync(Guid id);
    Task<ResponseModel<TK?>> GetAddressAsync(Guid id);

    #endregion

    #region Методы категорий
    Task<ResponseModel<Guid>> CreateCategoryAsync(CreateCategoryDto dto);
    Task<ResponseModel<CategoryDto?>> GetCategoryAsync(Guid id);
    Task<ResponseModel<List<CategoryDto?>>> GetAllCategoriesAsync();
    
    #endregion

    #region Методы работы с файлами

    Task<ResponseModel<string>> UploadFileAsync(CreateFileDto dto);
    Task<ResponseModel<string>> RemoveFileAsync(Guid id);
    Task<ResponseModel<byte[]>> GetFileAsync(Guid id);

    #endregion

    #region Методы поиска
    Task<List<ResponseModel>> SearchByTitle(string search);
    #endregion

    #region Методы Тэгов
    Task<ResponseModel<Guid>> CreateTagAsync(TagDto tag);
    
    #endregion

    #region Методы Тарифов

    Task<ResponseModel<Guid>> CreateTarifAsync(CreateTarifDto dto);
    Task<ResponseModel<bool>> DeleteTarifAsync(Guid id);

    #endregion

    #region Методы Тайм Юнитов
    Task<ResponseModel<Guid>> CreateAsync(CreateTimeUnitDto dto);
    Task<ResponseModel<TimeUnitDto?>> GetAsync(Guid id);
    Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync();

    #endregion
}