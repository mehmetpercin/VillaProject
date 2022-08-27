using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, Response<Guid>>
    {
        public Task<Response<Guid>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
