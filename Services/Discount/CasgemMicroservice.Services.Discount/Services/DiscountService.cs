using AutoMapper;
using CasgemMicroservice.Services.Discount.Context;
using CasgemMicroservice.Services.Discount.DTOs;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _dapperContext;
    private readonly IMapper _mapper;

    public DiscountService(DapperContext dapperContext, IMapper mapper)
    {
        _dapperContext = dapperContext;
        _mapper = mapper;
    }

    public async Task<Response<List<ResultDiscountCouponsDto>>> GetListCouponsAsync()
    {
        var results = await _dapperContext.DiscountCouponses.ToListAsync();

        return Response<List<ResultDiscountCouponsDto>>.Success(_mapper.Map<List<ResultDiscountCouponsDto>>(results), 200);
    }

    public async Task<Response<ResultDiscountCouponsDto>> GetCouponsAsync(int id)
    {
        var result = await _dapperContext.DiscountCouponses.FindAsync(id);

        return result == null ? Response<ResultDiscountCouponsDto>.Fail("Böyle bir Id bulunamadı!", 404) : Response<ResultDiscountCouponsDto>.Success(_mapper.Map<ResultDiscountCouponsDto>(result), 200);
    }

    public async Task<Response<NoContent>> CreateCouponsAsync(CreateDiscountCouponsDto discountCouponsDto)
    {
        var viewModel = _mapper.Map<DiscountCoupons>(discountCouponsDto);
        discountCouponsDto.CreatedTime = DateTime.Now;

        await _dapperContext.DiscountCouponses.AddAsync(viewModel);
        await _dapperContext.SaveChangesAsync();

        return Response<NoContent>.Success(201);
    }

    public async Task<Response<NoContent>> UpdateCouponsAsync(UpdateDiscountCouponsDto discountCouponsDto)
    {
        var existingResponse = await _dapperContext.DiscountCouponses.FindAsync(discountCouponsDto.Id);

        if (existingResponse == null)
            return Response<NoContent>.Fail("Güncellenecek kupon bulunamadı!", 404);

        _mapper.Map(discountCouponsDto, existingResponse);
        _dapperContext.DiscountCouponses.Update(existingResponse);
        await _dapperContext.SaveChangesAsync();

        return Response<NoContent>.Success(204);
    }

    public async Task<Response<NoContent>> DeleteCouponsAsync(int id)
    {

        var response = await _dapperContext.DiscountCouponses.FindAsync(id);

        if (response == null)
            return Response<NoContent>.Fail("Silinecek kupon bulunamadı!", 404);

        _dapperContext.Remove(response);
        await _dapperContext.SaveChangesAsync();

        return Response<NoContent>.Success(204);
    }
}