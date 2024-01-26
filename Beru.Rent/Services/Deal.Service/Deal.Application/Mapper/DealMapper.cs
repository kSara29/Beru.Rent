﻿using Deal.Api.DTO.Deal;

namespace Deal.Api.Mapper;

public static class DealMapper
{
    public static Domain.Models.Deal ToDomain(this CreateDealDto createDealDto)
        => new(createDealDto.AdId, createDealDto.TenantId, createDealDto.Cost, createDealDto.OwnerId, createDealDto.dbeg, createDealDto.dend);
}