﻿
using Deal.Api.DTO;
using Deal.Api.DTO.Booking;
using Deal.Api.Mapper;
using Deal.Application.Contracts.Booking;
using Deal.Application.DTO.Booking;
using Deal.Domain.Models;

namespace Deal.Application.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }   

    public async Task<bool> CancelReservationAsync(Booking booking)
    {
        return await (_bookingRepository.CancelReservationAsync(booking));
    }

    public async Task<bool> CreateBookingAsync(CreateBookingDto dto)
    {
        return await _bookingRepository.CreateBookingAsync(dto.ToDomain());
    }

    public async Task<DateTime[,]> GetAllBookingsAsync(Guid id)
    {
        return await _bookingRepository.GetAllBookingsAsync(id);
    }

    public async Task<List<Booking>> GetBookingsAsync(Guid id)
    {
        return await _bookingRepository.GetBookingsAsync(id);
    }
}