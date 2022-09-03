using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommandRequest : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
