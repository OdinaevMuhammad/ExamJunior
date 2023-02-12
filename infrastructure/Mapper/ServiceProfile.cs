using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace infrastructure.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<OrderDto, Order>()
            .ForMember(dest=> dest.ProductCategory , conf=> conf.MapFrom(src=> src.CategoryName));

            CreateMap<Order,GetOrders>()
            .ForMember(dest=> dest.Installment , conf=> conf.MapFrom(src=> (int)src.Installment));

        }
    }
}