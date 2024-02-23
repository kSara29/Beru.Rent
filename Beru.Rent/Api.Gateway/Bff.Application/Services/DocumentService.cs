using System.Net;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;


namespace Bff.Application.Services;

public class DocumentService  (ServiceHandler serviceHandler,
    IUserService userService, IAdService adService,IDealService dealService,
    IOptions<RequestToDealApi> jsonOptions
    ) :IDocumentService
{
        public async Task<ResponseModel<DocDataDto>> GenerateDoc(RequestById dto)
    {
        try
        {
            //получаю данные по сделке по id в Deal Service
            var deal = await dealService.GetDealAsync(new GetDealRequestDto{DealId = dto.Id});

            //получаю данные о товаре из объявления в Ad Service
            var ad = await adService.GetAdAsync(new RequestById { Id = deal.Data.AdId });

            //получаю данные владельца в User Service
            var ownerId = ad.Data.UserId;
            var owner = await userService.GetUserByIdAsync
                (ownerId.ToString());
            //получаю данные арендатора в User Service
            var tenantId = deal.Data.TenantId;
            var tenant = await userService.GetUserByIdAsync
                (tenantId.ToString());


            //Создаю модель с данными документа
            var doc = new DocDataDto();
            doc.DocNumber = deal.Data.Id.ToString();
                // заменить на дату создания сделки!!!!
                doc.TodayDate = DateTime.Today.Date.ToString("dd-MM-yyyy");
                doc.DocTown = ad.Data.AddressExtra.City ?? "Не указано";
                doc.ItemTitle = ad.Data.Title ?? "Не указано";
                doc.ItemDesc = ad.Data.Description ?? "Не указано";
                doc.ExtraConditions = ad.Data.ExtraConditions ?? "Не указано";
                
                doc.DealCost = deal.Data.Cost.ToString() ?? "Не указано";
                doc.DealDepositCost = deal.Data.Deposit.ToString() ?? "Не указано";
                doc.DealDateBegin = deal.Data.Dbeg.ToString();
                doc.DealDateEnd = deal.Data.Dend.ToString();
                doc.DealAddress = $"{ad.Data.AddressExtra.City} {ad.Data.AddressExtra.Street}" +
                                  $" {ad.Data.AddressExtra.House} {ad.Data.AddressExtra.Apartment}";
                doc.DealHourBegin = deal.Data.Dbeg.ToString();
                doc.DealHourEnd = deal.Data.Dend.ToString();

                doc.OwnerFio = $"{owner.Data.FirstName ?? "Не указано"} {owner.Data.LastName ?? "Не указано"}";
                doc.OwnerIin = owner.Data.Iin ?? "Не указано";
                doc.OwnerIdNumber = owner.Data.Iin ?? "Не указано";
                doc.OwnerEmail = owner.Data.Mail ?? "Не указано";
                doc.OwnerPhone = "+7" + (owner.Data.Phone ?? "Не указано");


                doc.TenantFio = $"{tenant.Data.FirstName} {tenant.Data.LastName}";
                doc.TenantIin = tenant.Data.Iin ?? "Не указано";
                doc.TenantIdNumber = tenant.Data.Iin ?? "Не указано";
                doc.TenantEmail = tenant.Data.Mail ?? "Не указано";
                doc.TenantPhone = "+7" + (tenant.Data.Phone ?? "Не указано");
                
            return ResponseModel<DocDataDto>.CreateSuccess(doc);
        }
        catch (Exception ex)
        {
            var errors = new List<ResponseError>();
            var error = new ResponseError();
            error.Message = ex.Message;
            errors.Add(error);
        return ResponseModel<DocDataDto>.CreateFailed(errors); 
        }

    }
    
}