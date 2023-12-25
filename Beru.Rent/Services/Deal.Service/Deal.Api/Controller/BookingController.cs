using Deal.Api.DTO;
using Deal.Application.Contracts.Booking;
using Microsoft.AspNetCore.Mvc;
using Minio;

namespace Deal.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private IBookingRepository _repository;
    private IBookingService _service;
    private readonly IMinioClient _minioClient;

    public BookingController(IBookingRepository repository, IBookingService service, IMinioClient minioClient)
    {
        _repository = repository;
        _service = service;
        _minioClient = minioClient;
    }
    
}