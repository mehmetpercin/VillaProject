﻿using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Commands.DeleteProductCommand
{
    public class DeleteProductCommandRequest : IRequest<Response<object>>
    {
        public int Id { get; set; }
    }
}