using Deal.Application.Contracts.Booking;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace Deal.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
 


    
      
}