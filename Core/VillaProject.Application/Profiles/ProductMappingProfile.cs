using AutoMapper;
using VillaProject.Application.Dtos.Products;
using VillaProject.Application.Features.Products.Commands.UpdateProductCommand;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
