using AutoMapper;
using VillaProject.Application.Dtos.Orders;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap();
        }
    }
}
