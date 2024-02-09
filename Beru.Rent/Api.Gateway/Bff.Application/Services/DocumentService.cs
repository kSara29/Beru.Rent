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
        try
        {
            //получаю данные по сделке по id в Deal Service
            var deal = await dealService.GetDealAsync(new GetDealRequestDto(dto.Id));

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
                doc.DocTown = ad.Data.AddressExtra.City;
                doc.ItemTitle = ad.Data.Title;
                doc.ItemDesc = ad.Data.Description;
                doc.ExtraConditions = ad.Data.ExtraConditions;
                
                doc.DealCost = deal.Data.Cost.ToString();
                doc.DealDepositCost = deal.Data.Deposit.ToString();
                doc.DealDateBegin = deal.Data.Dbeg.ToString();
                doc.DealDateEnd = deal.Data.Dend.ToString();
                doc.DealAddress = $"{ad.Data.AddressExtra.City} {ad.Data.AddressExtra.Street}" +
                                  $" {ad.Data.AddressExtra.House} {ad.Data.AddressExtra.Apartment}";
                doc.DealHourBegin = deal.Data.Dbeg.ToString();
                doc.DealHourEnd = deal.Data.Dend.ToString();

                doc.OwnerFio = $"{owner.Data.FirstName} {owner.Data.LastName}";
                doc.OwnerIin = owner.Data.Iin;
                doc.OwnerIdNumber = owner.Data.Iin;
                doc.OwnerEmail = owner.Data.Mail;
                doc.OwnerPhone = "+7" + owner.Data.Phone;


                doc.TenantFio = $"{tenant.Data.FirstName} {tenant.Data.LastName}";
                doc.TenantIin = tenant.Data.Iin;
                doc.TenantIdNumber = tenant.Data.Iin;
                doc.TenantEmail = tenant.Data.Mail;
                doc.TenantPhone = "+7" + tenant.Data.Phone;

            
            var i = doc;
            
            //Создаю заполненный файл
            //var dataDir = "../../../DealDocTemplate/";
            var dataDir ="/DealDocTemplate/";
            Document file = new Document(dataDir + "rentDoc.docx");
            var docProperties = typeof(DocDataDto).GetProperties();

            foreach (var property in docProperties)
            {
                var placeholder = $"_{property.Name}_";
                var value = property.GetValue(doc)?.ToString() ?? "Не указано";
                file.Range.Replace(placeholder, value, new FindReplaceOptions());
            }

            file.Save(dataDir + DateTime.Today.ToFileTime());

            //Отправляю заполненный файл на фронт

            byte[] pdfBytes = ConvertToPdf(file);

            // Отправить PDF на фронтенд
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(pdfBytes);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = doc.DocNumber + ".pdf"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return ResponseModel<byte[]>.CreateSuccess(pdfBytes);
        }
        catch (Exception ex)
        {
            var errors = new List<ResponseError>();
            var error = new ResponseError();
            error.Message = ex.Message;
            errors.Add(error);
        return ResponseModel<byte[]>.CreateFailed(errors); 
        }

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