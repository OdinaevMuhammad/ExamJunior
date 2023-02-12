using System.Net.Http.Headers;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Wrapper;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class OrderServiceController : ControllerBase
    {
        private readonly OrderService _OrderService;
        public OrderServiceController(OrderService orderService)
        {

            _OrderService = orderService;

        }
        [HttpGet("GetOrders")]
        public async Task<Response<List<GetOrders>>> GetOrders()
        {
            return await _OrderService.GetOrders();
        }
        [HttpPost("GetTotalAmountOfPayment")]
        public async Task<Response<double>> GetTotalAmountOfPayment([FromForm] OrderDto order)
        {
            
                if (ModelState.IsValid)
                {
                    return await _OrderService.GetTotalAmountOfPayment(order);
                }
                else
                {

                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                    return new Response<double>(System.Net.HttpStatusCode.BadGateway, errors);
                }

            


        }
    }
}