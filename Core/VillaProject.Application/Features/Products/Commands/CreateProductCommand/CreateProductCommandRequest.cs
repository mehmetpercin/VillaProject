using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandRequest : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
