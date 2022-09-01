using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommandRequest : IRequest<Response<object>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
