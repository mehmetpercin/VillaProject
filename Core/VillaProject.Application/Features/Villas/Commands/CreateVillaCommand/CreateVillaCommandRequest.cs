﻿using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Villas.Commands.CreateVillaCommand
{
    public class CreateVillaCommandRequest : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
