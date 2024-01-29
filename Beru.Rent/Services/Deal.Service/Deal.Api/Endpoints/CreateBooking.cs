using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class CreateBooking(IBookingService service) : Endpoint<CreateBookingRequestDto, ResponseModel<BoolResponseDto>>
{
    public override void Configure()
    {
        Post("/api/booking/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookingRequestDto model, CancellationToken ct)
    {
        //Проверяем через валидацию. Если валидация не пройдена правильно создаем responseModel с результатом CreateFailed,
        //с причиной ошибки(код и сообщение)
        
        var results = await service.CreateBookingAsync(model);
        var res = ResponseModel<BoolResponseDto>.CreateSuccess(results);
        await SendAsync(res, cancellation: ct);
    }
}