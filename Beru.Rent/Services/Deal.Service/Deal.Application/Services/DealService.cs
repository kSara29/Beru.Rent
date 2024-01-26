﻿using Deal.Api.DTO.Deal;
using Deal.Application.Contracts.Deal;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    
    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }
    
    public Task<CreateDealDto> CreateDealAsync(Guid Id)
    {
        return (_dealRepository.CreateDealAsync(Id)); 
    }
}