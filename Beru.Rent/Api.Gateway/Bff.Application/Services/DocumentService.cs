using System.Net;
using Aspose.Words.Replacing;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;
using User.Dto.ResponseDto;
using Ad.Dto.GetDtos;
using Aspose.Words;
using Aspose.Words.Replacing;
using Microsoft.Net.Http.Headers;
using User.Dto.RequestDto;
using ContentDispositionHeaderValue = System.Net.Http.Headers.ContentDispositionHeaderValue;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Bff.Application.Services;

public class DocumentService  (ServiceHandler serviceHandler,
    IUserService userService, IAdService adService,IDealService dealService,
    IOptions<RequestToDealApi> jsonOptions
    ) :IDocumentService
{
        public async Task<ResponseModel<byte[]>> GenerateDoc(RequestById dto)
    {
        //получаю данные по сделке по id в Deal Service
        var deal = await dealService.GetDealAsync(new GetDealRequestDto(dto.Id));
        
        //получаю данные о товаре из объявления в Ad Service
        var ad = await adService.GetAdAsync(new RequestById{Id = deal.Data.adId});
        
        //получаю данные владельца в User Service
        var ownerId = ad.Data.UserId;
        var owner = await userService.GetUserByIdAsync
            (new GetUserByIdRequest { Id = ownerId.ToString() });
        //получаю данные арендатора в User Service
        var tenantId = deal.Data.tenantId; 
        var tenant = await userService.GetUserByIdAsync
            (new GetUserByIdRequest { Id = tenantId });

        
        //Создаю модель с данными документа
        var doc = new DocDataDto
        {
            DocNumber = deal.Data.dealId.ToString() ?? "Не указано",
            // заменить на дату создания сделки!!!!
            TodayDate = DateTime.Today.Date.ToString("dd-MM-yyyy"), 
            DocTown = ad.Data.AddressExtra.City ?? "Не указано",
            
            ItemTitle = ad.Data.Title ?? "Не указано",
            ItemDesc = ad.Data.Description ?? "Не указано",
            ExtraConditions = ad.Data.ExtraConditions ?? "Не указано",
            
            DealCost = deal.Data.cost.ToString() ?? "Не указано",
            DealDepositCost = deal.Data.Deposit.ToString() ?? "Не указано",
            DealDateBegin = deal.Data.dbeg.ToString() ?? "Не указано",
            DealDateEnd = deal.Data.dend.ToString() ?? "Не указано",
            DealAddress = $"{ad.Data.AddressExtra.City} {ad.Data.AddressExtra.Street}" +
                          $" {ad.Data.AddressExtra.House} {ad.Data.AddressExtra.Apartment}" ?? "Не указано",
            DealHourBegin= deal.Data.dbeg.ToString() ?? "Не указано",
            DealHourEnd = deal.Data.dend.ToString() ?? "Не указано",
           
            OwnerFio = $"{owner.Data.FirstName} {owner.Data.LastName}" ?? "Не указано",
            OwnerIin = owner.Data.Iin ?? "Не указано",
            OwnerIdNumber = owner.Data.Iin ?? "Не указано",
            OwnerEmail = owner.Data.Mail ?? "Не указано",
            OwnerPhone = "+7"+ owner.Data.Phone ?? "Не указано",
            
            
            TenantFio = $"{tenant.Data.FirstName} {tenant.Data.LastName}" ?? "Не указано",
            TenantIin = tenant.Data.Iin ?? "Не указано",
            TenantIdNumber = tenant.Data.Iin ?? "Не указано",
            TenantEmail = tenant.Data.Mail ?? "Не указано",
            TenantPhone = "+7"+ tenant.Data.Phone ?? "Не указано"

        };
        //Создаю заполненный файл
        var dataDir = "../../../DealDocTemplate/";
        Document file = new Document(dataDir + "rentDoc.docx");
        var docProperties = typeof(DocDataDto).GetProperties();

        foreach (var property in docProperties)
        {
            var placeholder = $"_{property.Name}_";
            var value = property.GetValue(doc)?.ToString() ?? "Не указано";
            file.Range.Replace(placeholder, value, new FindReplaceOptions());
        }

        //Отправляю заполненный файл на фронт
        
        byte[] pdfBytes = ConvertToPdf(file);

        // Отправить PDF на фронтенд
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new ByteArrayContent(pdfBytes);
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = doc.DocNumber+".pdf"
        };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

        return ResponseModel<byte[]>.CreateSuccess(pdfBytes);
    }
        

    private byte[] ConvertToPdf(Document doc)
    {
        // Создать поток для хранения PDF
        using (MemoryStream pdfStream = new MemoryStream())
        {
            // Сохранить документ в формате PDF
            doc.Save(pdfStream, SaveFormat.Pdf);
            return pdfStream.ToArray();
        }
    }
}