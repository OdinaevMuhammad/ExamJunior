using System.IO;
namespace infrastructure.Services;

using System;
using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class OrderService
{
    private DataContext _context;
    private IMapper _mapper;

    public OrderService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetOrders>>> GetOrders()
    {
        // var mapped = _mapper.Map<List<GetOrders>>(_context.Orders.ToList());
        // return new Response<List<GetOrders>>(mapped);

        var linq = await(from o in _context.Orders
                        orderby o.ProductCategory
                        select new GetOrders  {
                            Id = o.Id,
                            ProductCategory = o.ProductCategory,
                            Installment = (int)o.Installment,
                            Percent = o.Percent,
                            PhoneNumber =  o.PhoneNumber,
                            ProductAmount = o.ProductAmount,
                            ProductId = o.ProductId,
                            ProductName = o.ProductName,
                            ProductPrice = o.ProductPrice,
                           StartDate = o.StartDate  

                        }).ToListAsync();
                        return new Response<List<GetOrders>>(linq);

    }
    public async Task<Response<double>> GetTotalAmountOfPayment(OrderDto order)
    {
        try
        {
            var mapped = _mapper.Map<Order>(order);
        if (order.CategoryName == ProductCategory.Smartphone)
        {
            if (order.Installment == InstallmentEnum.Twelve)
            {
                mapped.Percent = 3;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else if (order.Installment == InstallmentEnum.Eighteen)
            {
                mapped.Percent = 6;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else if (order.Installment == InstallmentEnum.TwentyFour)
            {
                mapped.Percent = 9;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else
            {
                mapped.ProductAmount = order.ProductPrice;
            }
            mapped.ProductId = 1;
        }
        if (order.CategoryName == ProductCategory.Computer)
        {
            if (order.Installment == InstallmentEnum.Eighteen)
            {
                mapped.Percent = 4;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else if (order.Installment == InstallmentEnum.TwentyFour)
            {
                mapped.Percent = 8;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else
            {
                mapped.ProductAmount = order.ProductPrice;
            }

            mapped.ProductId = 2;
        }
        if (order.CategoryName == ProductCategory.TV)
        {

            if (order.Installment == InstallmentEnum.TwentyFour)
            {
                mapped.Percent = 5;
                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
            }
            else
            {
                mapped.ProductAmount = order.ProductPrice;
            }

            mapped.ProductId = 3;

            
        }
        mapped.StartDate = DateTime.UtcNow;
        await _context.Orders.AddAsync(mapped);
        await _context.SaveChangesAsync();
        return new Response<double>(mapped.ProductAmount);

        }
        catch (System.Exception ex)
        {
            return new Response<double>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

}
